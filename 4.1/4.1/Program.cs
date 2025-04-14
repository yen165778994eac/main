using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Сравнение алгоритмов сортировки");

            int[] array = GenerateRandomArray(10, 1, 100);

            Console.WriteLine("\nИсходный массив:");
            PrintArray(array);

            // Копии массива для разных сортировок
            int[] bubbleArray = (int[])array.Clone();
            int[] quickArray = (int[])array.Clone();
            int[] insertionArray = (int[])array.Clone();

            // Сортировка пузырьком
            BubbleSort(bubbleArray);
            Console.WriteLine("\nСортировка пузырьком:");
            PrintArray(bubbleArray);

            // Быстрая сортировка
            QuickSort(quickArray, 0, quickArray.Length - 1);
            Console.WriteLine("\nБыстрая сортировка:");
            PrintArray(quickArray);

            // Сортировка вставками
            InsertionSort(insertionArray);
            Console.WriteLine("\nСортировка вставками:");
            PrintArray(insertionArray);
        }

        // Генерация случайного массива
        static int[] GenerateRandomArray(int size, int min, int max)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(min, max);
            }
            return array;
        }

        // Вывод массива в консоль
        static void PrintArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        // Сортировка пузырьком
        static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        // Меняем элементы местами
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        // Быстрая сортировка
        static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(array, left, right);

                if (pivot > 1)
                    QuickSort(array, left, pivot - 1);

                if (pivot + 1 < right)
                    QuickSort(array, pivot + 1, right);
            }
        }

        static int Partition(int[] array, int left, int right)
        {
            int pivot = array[left];
            while (true)
            {
                while (array[left] < pivot)
                    left++;

                while (array[right] > pivot)
                    right--;

                if (left < right)
                {
                    if (array[left] == array[right]) return right;

                    int temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        // Сортировка вставками
        static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
        }
    }
}
