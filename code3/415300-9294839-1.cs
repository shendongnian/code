    public static class DebugHelper
    {
        // Based on the CodeProject article 
        // http://www.codeproject.com/Articles/21400/Navigating-Exception-Backtraces-in-Visual-Studio
        
        private static readonly string StarSeparator = new String('*', 80);
        private static readonly string DashSeparator = new String('-', 80);
    
        /// <summary>
        /// Prints the exception using a format recognized by the Visual Studio console parser.
        /// Allows for quick navigation of exception call stack.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public static void PrintExceptionToConsole(Exception exception)
        {
            PrintExceptionToConsole(exception, String.Empty);
        }
    
        private static void PrintExceptionToConsole(Exception exception, string indent)
        {
            Console.WriteLine(indent + StarSeparator);
            Console.WriteLine(indent + "{0}: \"{1}\"", exception.GetType().Name, exception.Message);
            Console.WriteLine(indent + new String('-', 80));
            if (exception.InnerException != null)
            {
                Console.WriteLine(indent + "InnerException:");
                PrintExceptionToConsole(exception.InnerException, indent + "   ");
            }
    
            string[] lines = exception.StackTrace.Split(new String[] { " at " }, StringSplitOptions.RemoveEmptyEntries)
                                                    .Select(x => x.Trim())
                                                    .Where(x => !String.IsNullOrEmpty(x))
                                                    .ToArray();
    
            foreach (var line in lines)
            {
                string[] parts = line.Split(new String[] { " in " }, StringSplitOptions.RemoveEmptyEntries);
                string classInfo = parts[0];
    
                if (parts.Length == 2)
                {
                    parts = parts[1].Trim().Split(new String[] { "line" }, StringSplitOptions.RemoveEmptyEntries);
                    string sourceFile = parts[0];
                    int lineNumber = Int32.Parse(parts[1]);
    
                    Console.WriteLine(indent + "  {0}({1},1):   {2}", sourceFile.TrimEnd(':'), lineNumber, classInfo);
                }
                else
                    Console.WriteLine(indent + "  " + classInfo);
            }
    
            Console.WriteLine(indent + StarSeparator);
        }
    
    }
