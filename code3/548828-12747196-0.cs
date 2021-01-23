    using System;
    
    class Test
    {
        static void PrintValues(string title = "Default",
                                params int[] values)
        {
            Console.WriteLine("{0}: {1}", title, 
                              string.Join(", ", values));
        }
        
        static void Main()
        {
            // Explicitly specify the argument name and build the array
            PrintValues(values: new int[] { 10, 20 });
            // Explicitly specify the argument name and provide a single value
            PrintValues(values: 10);
            // No arguments: default the title, empty array
            PrintValues();
        }
    }
