    using System;
    namespace ArraySlice
    {
        class Program
        {
            static void Main(string[] args)
            {
                byte[] array1 = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };
                byte[] array2 = GetSlice<byte>(array1, 5, 10);
                for (int i = 0; i < array2.Length; i++)
                {
                    Console.WriteLine(array2[i]);
                }
                Console.ReadKey();
            }
            static T[] GetSlice<T>(T[] array, int start, int length)
            {
                T[] result = new T[length];
                for (int i = 0; i < length; i++)
                {
                    result[i] = ((start + i) < array.Length) ? array[start + i] : default(T);
                }
                return result;
            }
        }
    }
