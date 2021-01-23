    using System;
    using System.Collections.Generic;
    class Program
    {
        private static unsafe List<long> ParseNumbers(char[] input)
        {
            var r = new List<long>();
            fixed (char* begin = input)
            {
                char* it = begin, end = begin + input.Length;
                while (true)
                {
                    while (it != end && (*it < '0' || *it > '9')) 
                        ++it;
                    if (it == end) break;
                    long accum = 0;
                    while (it != end && *it >= '0' && *it <= '9') 
                        accum = accum * 10 + (*(it++) - '0');
                    r.Add(accum);
                }
            }
            return r;
        }
        static void Main()
        {
            foreach (var number in ParseNumbers("ASDFG 3457 ASDFG.\n 123457".ToCharArray()))
            {
                Console.WriteLine(number);
            }
        }
    }
