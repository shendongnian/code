    using System;
    using System.Collections;
    
    class Program
    {
        static void Main(string[] args)
        {
            BitArray bits = new BitArray(8);
            bits[0] = false;
            bits[1] = true;
            
            int[] array = new int[1];
            bits.CopyTo(array, 0);
            Console.WriteLine(array[0]); // Prints 2
        }
    }
