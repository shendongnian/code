     static object lockObj = new object();
     public static void WriteError(string text)
     {
        lock(lockObj)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t" + text);
            Console.ForegroundColor = ConsoleColor.White;
        }
     }
