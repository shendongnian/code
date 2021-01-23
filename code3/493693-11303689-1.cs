    using System; 
     
     
    namespace Lab16 
    { 
    class Program 
    { 
        static void Main(string[] args) 
        { 
            int arraySize; 
     
            Console.WriteLine("How big of an Array? "); 
            while(!int.TryParse(Console.ReadLine(), out arraySize))
            { 
                Console.WriteLine("How big of an Array? ");
            }
            int[] array = new int[arraySize]; 
            for (int i = 0; i < arraySize; i++) 
            { 
                int arrayValue;
                Console.WriteLine(string.Format("Value of element {0}: ", i));
                while(!int.TryParse(Console.ReadLine(), out arrayValue))
                     Console.WriteLine(string.Format("Value of element {0}: ", i));
                array[i] = arrayValue;
            } 
        } 
    } 
    }
