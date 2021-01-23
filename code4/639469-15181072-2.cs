    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    namespace ConsoleApplication2
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var sentences = new List<string>
                {
                    "Little Red Riding Hood",
                    "Three Little Pigs",
                    "Jack and the Beanstalk"
                };
                foreach (var sentence in sentences)
                {
                    Console.WriteLine("----------------------------------");
                    foreach (var permutation in Permute(sentence.Split(' ')))
                    {
                        foreach (string word in permutation)
                        {
                            Console.Write(word + " ");
                        }
                        Console.WriteLine();
                    }
                }
            }
            /// <summary>
            /// Provides a sequence of enumerators for obtaining all permutations of a sequence.
            /// Each enumeration in the returned sequence itself enumerates one of the permutations of the input sequence.
            /// Use two nested foreach statements to visit each item in each permuted sequence.
            /// </summary>
            public static IEnumerable<IEnumerable<T>> Permute<T>(IEnumerable<T> sequence)
            {
                return permute(sequence, sequence.Count());
            }
            // Returns an enumeration of enumerators, one for each permutation of the input.
            private static IEnumerable<IEnumerable<T>> permute<T>(IEnumerable<T> sequence, int count)
            {
                if (count == 0)
                {
                    yield return new T[0];
                }
                else
                {
                    int startingElementIndex = 0;
                    foreach (T startingElement in sequence)
                    {
                        IEnumerable<T> remainingItems = allExcept(sequence, startingElementIndex);
                        foreach (IEnumerable<T> permutationOfRemainder in permute(remainingItems, count - 1))
                        {
                            yield return concat<T>(new T[] { startingElement }, permutationOfRemainder);
                        }
                        ++startingElementIndex;
                    }
                }
            }
            // Implements the recursive part of Permute<T>
            private static void permute<T>(T[] items, int item, T[] permutation, bool[] used, Action<T[]> output)
            {
                for (int i = 0; i < items.Length; ++i)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        permutation[item] = items[i];
                        if (item < (items.Length - 1))
                        {
                            permute(items, item + 1, permutation, used, output);
                        }
                        else
                        {
                            output(permutation);
                        }
                        used[i] = false;
                    }
                }
            }
            // Enumerates over all items in the input, skipping over the item with the specified index.
            private static IEnumerable<T> allExcept<T>(IEnumerable<T> input, int indexToSkip)
            {
                int index = 0;
                foreach (T item in input)
                {
                    if (index != indexToSkip)
                    {
                        yield return item;
                    }
                    ++index;
                }
            }
            // Enumerates over contents of two lists sequentially.
            private static IEnumerable<T> concat<T>(IEnumerable<T> a, IEnumerable<T> b)
            {
                foreach (T item in a)
                {
                    yield return item;
                }
                foreach (T item in b)
                {
                    yield return item;
                }
            }
        }
    }
