    public static void Main(string[] args)
            {
                string str = @"stackoverflow(stack:stackoverflow)overstackflow(over:stackoverflow)";
                Console.WriteLine(ExtractString(str));
            }
    
            static string ExtractString(string s)
            {
                var start = "(";
                int startIndex = s.IndexOf(start) + start.Length;
                int endIndex = s.IndexOf(":", startIndex);
                return s.Substring(startIndex, endIndex - startIndex);
            }
