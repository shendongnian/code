    using System;
    using System.Collections.Generic;
    class Program
    {
        private static IEnumerable<long> ParseNumbers(string stream)
        {
            bool eos = false;
            using (var it = stream.GetEnumerator())
                do
                {
                    Func<bool> advance = () => !(eos = !it.MoveNext());
                    while (advance() && !char.IsDigit(it.Current)) ;
                    long accum = 0;
                    do accum = accum * 10 + (it.Current - '0');
                    while (advance() && char.IsDigit(it.Current));
                    yield return accum;
                }
                while (!eos);
        }
        static void Main()
        {
            foreach (var num in ParseNumbers("ASDFG 3457 ASDFG.\n 123457"))
            {
                Console.WriteLine(num);
            }
        }
    }
