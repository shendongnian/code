    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string x = "a\r\nb\r\nc\r\nd\r\ne\r\nf\r\ng\r\nh\r\ni\r\nj\r\nk\r\nl\r\nm\r\nn\r\no\r\np";
                foreach(var line in x.SplitAsEnumerable("\r\n").TakeLast(10))
                    Console.WriteLine(line);
                Console.ReadKey();
            }
        }
        static class LinqExtensions
        {
            public static IEnumerable<string> SplitAsEnumerable(this string source)
            {
                return SplitAsEnumerable(source, ",");
            }
            public static IEnumerable<string> SplitAsEnumerable(this string source, string seperator)
            {
                return SplitAsEnumerable(source, seperator, false);
            }
            public static IEnumerable<string> SplitAsEnumerable(this string source, string seperator, bool returnSeperator)
            {
                if (!string.IsNullOrEmpty(source))
                {
                    int pos = 0;
                    do
                    {
                        int newPos = source.IndexOf(seperator, pos, StringComparison.InvariantCultureIgnoreCase);
                        if (newPos == -1)
                        {
                            yield return source.Substring(pos);
                            break;
                        }
                        yield return source.Substring(pos, newPos - pos);
                        if (returnSeperator) yield return source.Substring(newPos, seperator.Length);
                        pos = newPos + seperator.Length;
                    } while (true);
                }
            }
            public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int count)
            {
                List<T> items = new List<T>();
                foreach (var item in source)
                {
                    items.Add(item);
                    if (items.Count > count) items.RemoveAt(0);
                }
                return items;
            }
        }
    }
