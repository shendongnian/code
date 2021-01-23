    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        public static class Program
        {
            static void Main(string[] args)
            {
                var a = new List<double> { 1, 2, 3 };
                var b = new List<double> { 10, 20, 30 };
                var c = new List<double> { 100, 200, 300 };
                var lists = new List<List<double>> {a, b, c};
                foreach (var combination in Combine(lists))
                {
                    Console.WriteLine(asString(combination));
                }
            }
            static string asString(IEnumerable<double> data)
            {
                return "(" + string.Join(",", data) + ")";
            }
            /// <summary>
            /// Calculates the n-ary Cartesian Product (i.e. all possible combinations) of items taken from any
            /// number of sequences.
            /// </summary>
            /// <typeparam name="T">The type of the items in the sequences.</typeparam>
            /// <param name="sequences">The sequences to combine.</param>
            /// <returns>An enumerator that yields all possible combinations of items.</returns>
            /// <remarks>
            /// This code is taken from http://blogs.msdn.com/b/ericlippert/archive/2010/06/28/computing-a-cartesian-product-with-linq.aspx
            /// 
            /// If the sequences are ABC and 123, the output will be A1, A2, A3, B1, B2, B3, C1, C2, C3.
            /// </remarks>
            public static IEnumerable<IEnumerable<T>> Combine<T>(IEnumerable<IEnumerable<T>> sequences)
            {
                IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() };
                return sequences.Aggregate(
                  emptyProduct,
                  (accumulator, sequence) =>
                    from accseq in accumulator
                    from item in sequence
                    select accseq.Concat(new[] { item }));
            }
        }
    }
