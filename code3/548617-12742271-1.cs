    using System;
    using System.Text;
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                string text = "this is a testxxx of my data yxxx and there are many of these xxx parts yxxx";
                string separator = "xxx";
                var result = new StringBuilder();
                int index = 0;
                while (true)
                {
                    int start = text.IndexOf(separator, index);
                    if (start < 0)
                    {
                        result.Append(text.Substring(index));
                        break;
                    }
                    result.Append(text.Substring(index, start - index));
                    int end = text.IndexOf(separator, start + separator.Length);
                    if (end < 0)
                    {
                        throw new InvalidOperationException("Unbalanced separators.");
                    }
                    start += separator.Length;
                    result.Append(separator);
                    result.Append(processPart(text.Substring(start, end-start)));
                    result.Append(separator);
                    index = end + separator.Length;
                }
                Console.WriteLine(result);
            }
            private static string processPart(string part)
            {
                return ">>" + part + "<<";
            }
        }
    }
