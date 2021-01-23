    using System;
    public static class ConsoleExtensions
    {
        public static void Main()
        {
            string entry = ConsoleExtensions.ReadKeys(
                s => { StringToDouble(s) /* might throw */; return true; });
            
            double result = StringToDouble(entry);
            
            Console.WriteLine();
            Console.WriteLine("Result was {0}", result);
        }
        public static double StringToDouble(string s)
        {
            try
            {
                return double.Parse(s);
            }
            catch (FormatException)
            {
                // handle trailing E and +/- signs
                return double.Parse(s + '0');
            }
            // anything else will be thrown as an exception
        }
        public static string ReadKeys(Predicate<string> check)
        {
            string valid = string.Empty;
            
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    return valid;
                }
                
                bool isValid = false;
                char keyChar = key.KeyChar;
                string candidate = valid + keyChar;
                try
                {
                    isValid = check(candidate);
                }
                catch (Exception)
                {
                    // if this raises any sort of exception then the key wasn't valid
                    // one of the rare cases when catching Exception is reasonable
                    // (since we really don't care what type it was)
                }
                
                if (isValid)
                {
                    Console.Write(keyChar);
                    valid = candidate;
                }        
            }    
        }
    }
