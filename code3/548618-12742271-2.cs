    using System;
    using System.Text;
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                string text = "this is a test<pre> of my data y</pre> and there are many of these <pre> parts y</pre>";
                string separator1 = "<pre>";
                string separator2 = "</pre>";
                var result = new StringBuilder();
                int index = 0;
                while (true)
                {
                    int start = text.IndexOf(separator1, index);
                    if (start < 0)
                    {
                        result.Append(text.Substring(index));
                        break;
                    }
                    result.Append(text.Substring(index, start - index));
                    int end = text.IndexOf(separator2, start + separator1.Length);
                    if (end < 0)
                    {
                        throw new InvalidOperationException("Unbalanced separators.");
                    }
                    start += separator1.Length;
                    result.Append(separator1);
                    result.Append(processPart(text.Substring(start, end-start)));
                    result.Append(separator2);
                    index = end + separator2.Length;
                }
                Console.WriteLine(result);
            }
            private static string processPart(string part)
            {
                return "|" + part + "|";
            }
        }
    }
