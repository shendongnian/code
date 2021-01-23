    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        public class Program
        {
            [STAThread]
            private static void Main()
            {
                var stringList = new List<string> {"One", "Two", "Three"};
                IEnumerable<string> originalSequence = stringList;
                var newSequence = originalSequence.Concat("Four");
                foreach (var text in newSequence)
                {
                    Console.WriteLine(text); // Prints "One" "Two" "Three" "Four".
                }
            }
        }
        public static class EnumerableExt
        {
            /// <summary>Concatenates a scalar to a sequence.</summary>
            /// <typeparam name="T">The type of elements in the sequence.</typeparam>
            /// <param name="sequence">a sequence.</param>
            /// <param name="item">The scalar item to concatenate to the sequence.</param>
            /// <returns>A sequence which has the specified item appended to it.</returns>
            /// <remarks>
            /// The standard .Net IEnumerable extensions includes a Concat() operator which concatenates a sequence to another sequence.
            /// However, it does not allow you to concat a scalar to a sequence. This operator provides that ability.
            /// </remarks>
            public static IEnumerable<T> Concat<T>(this IEnumerable<T> sequence, T item)
            {
                return sequence.Concat(new[] { item });
            }
        }
    }
