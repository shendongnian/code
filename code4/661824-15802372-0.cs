    namespace Reverse4Loop 
    {
        class Program
        {
            static void Main()
            {
            int[] array = { 1, 2, 3, 4 };
            foreach (int value in array)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine();
    
            int arrayLength = array.length;
    
            int[] array2 = new int[arrayLength];
            for(int i = 0; i < array.length; i++)
            {
                array2[arrayLength - i + 1] = array[i];
            }
            Array.copy(array2, array, arrayLength);
        }
    }
