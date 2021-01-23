    internal static class Extensions
    {
        public static void WriteLineIf(this TextWriter tw, bool condition, string text)
        {
            if (condition)
            {
                tw.WriteLine(text);
            }
        }
    }
