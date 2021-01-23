    (Enumerable.Range(0, a_1),
     Enumerable.Range(0, a_2),
     .
     .
     .,
     Enumerable.Range(0, a_n)
    )
    using System.Linq;
    using System.Collections.Generic;
    using System;
    
    static class EnumerableExtensions {
        // credit: Eric Lippert
        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(
            this IEnumerable<IEnumerable<T>> sequences
        ) {
            IEnumerable<IEnumerable<T>> emptyProduct = 
                new[] { Enumerable.Empty<T>() };
            return sequences.Aggregate(
                emptyProduct,
                (accumulator, sequence) =>
                     from accseq in accumulator
                     from item in sequence
                     select accseq.Concat(new[] { item })
            );
        }
    }
    
    class Program {
        public static void Main(string[] args) {
            int[,,] array = new int[5, 4, 3];
            var dimensions = 
                Enumerable.Range(0, array.Rank)
                          .Select(r => Enumerable.Range(0, array.GetLength(r)));
            var indexes = dimensions.CartesianProduct();
            foreach(var index in indexes) {
                Console.WriteLine(String.Join(",", index));
            }
        }
    }
