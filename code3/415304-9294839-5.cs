    public static class DebugHelper
    {
        // Original idea taken from the CodeProject article 
        // http://www.codeproject.com/Articles/21400/Navigating-Exception-Backtraces-in-Visual-Studio
        private static readonly string StarSeparator = new String('*', 80);
        private static readonly string DashSeparator = new String('-', 80);
        private const string TabString = "   ";
        /// <summary>
        /// Prints the exception using a format recognized by the Visual Studio console parser.
        /// Allows for quick navigation of exception call stack.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public static void PrintExceptionToConsole(Exception exception)
        {
            using (var indentedTextWriter = new IndentedTextWriter(Console.Out, TabString))
            {                
                var indentLevel = 0;
                while (exception != null)
                {
                    indentedTextWriter.Indent = indentLevel;
                    indentedTextWriter.Write(FormatExceptionForDebugLineParser(exception));
                    exception = exception.InnerException;
                    indentLevel++;
                }
            }
        }
        private static string FormatExceptionForDebugLineParser(Exception exception)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(StarSeparator);
            result.AppendLineFormat("  {0}: \"{1}\"", exception.GetType().Name, exception.Message);
            result.AppendLine(DashSeparator);
            // Split lines into method info and filename / line number
            string[] lines = exception.StackTrace.Split(new string[] { " at " }, StringSplitOptions.RemoveEmptyEntries)
                                                    .Select(x => x.Trim())
                                                    .Where(x => !String.IsNullOrEmpty(x))
                                                    .ToArray();
            foreach (var line in lines)
            {
                string[] parts = line.Split(new string[] { " in " }, StringSplitOptions.RemoveEmptyEntries);
                string methodInfo = parts[0];
                if (parts.Length == 2)
                {
                    string[] subparts = parts[1].Split(new string[] { ":line " }, StringSplitOptions.RemoveEmptyEntries);
                    result.AppendLineFormat("  {0}({1},1): {2}", subparts[0], Int32.Parse(subparts[1]), methodInfo);
                }
                else
                    result.AppendLineFormat("  {0}", methodInfo);
            }
            result.AppendLine(StarSeparator);
            return result.ToString();
        }
    }
