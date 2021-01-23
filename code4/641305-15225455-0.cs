    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            string text = "22";
            int value;
            int.TryParse(text, NumberStyles.HexNumber, 
                         CultureInfo.InvariantCulture, out value);
            Console.WriteLine(value); // Prints 34
        }
    }
