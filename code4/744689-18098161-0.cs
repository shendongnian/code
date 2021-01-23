    using System;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                int length = 10;
    
                for (int i = 0; i < length; i++)
                {
                    string result = String.Format("{0}{1}{2}{3}",
                         fillWithStarFromLeft(i + 1, length),
                         fillWithStarFromLeft(length - i, length),
                         fillWithStarFromRight(length - i, length),
                         fillWithStarFromRight(i + 1, length)
                         );
    
                    Console.WriteLine(result);
                }
    
                Console.ReadKey();
            }
    
            private static object fillWithStarFromRight(int length, int segmentlength)
            {
                string result = String.Empty;
    
                for (int i = 0; i < length; i++)
                {
                    result += "*";
                }
    
                return result.PadLeft(segmentlength, ' ');
            }
    
            private static string fillWithStarFromLeft(int length, int segmentlength)
            {
                string result = String.Empty;
    
                for (int i = 0; i < length; i++)
                {
                    result += "*";
                }
    
                return result.PadRight(segmentlength, ' ');
            }
        }
    }
