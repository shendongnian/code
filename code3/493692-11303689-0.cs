    using System; 
     
     
    namespace Lab16 
    { 
    class Program 
    { 
        static void Main(string[] args) 
        { 
            int value; 
     
            Console.Write("How big of an Array? "); 
            int arraySize = int.Parse(Console.ReadLine()); 
            // I would loop until "exit" or array size was greater than 0, but an exception works too :)
            if(arraySize < 1) throw new Exception("Array size must be greater than 0");
            int[] array = new int[arraySize]; 
            for (int i = 0; i < arraySize; i++) 
            { 
                Console.Write("First Value: "); 
                array[i] = int.Parse(Console.ReadLine());
            } 
        } 
    } 
    }
