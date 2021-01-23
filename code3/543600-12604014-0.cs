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
                Console.WriteLine("Enter the string you want to search within.");
                string hayStack = Console.ReadLine();
                Console.WriteLine("Enter the string you want to search for.");
                string needle = Console.ReadLine();
    
                var ps = new PatternSearch<char>(needle.ToCharArray());
    
                Console.WriteLine();
                Console.WriteLine();
    
                Console.WriteLine(hayStack);
    
                var matches = ps.Matches(hayStack.ToCharArray()).ToList();
    
                for (int i = 0; i < hayStack.Length; i++)
                    Console.Write(matches.Contains(i) ? "↑" : " ");
    
                Console.WriteLine();
    
                Console.ReadLine();
            }
        }
    
        /// <summary>Implements a pattern searching algorithm with <b>O(nm)</b> worst-case performance.</summary>
        /// <typeparam name="T">The data type of the array to search.</typeparam>
        public class PatternSearch<T>
        {
            private struct MatchInfo
            {
                public MatchInfo(int startIndex, int matchLength)
                {
                    this.StartIndex = startIndex;
                    this.MatchLength = matchLength;
                }
                public int StartIndex;
                public int MatchLength;
            }
    
            private IEnumerable<T> pattern;
            private List<MatchInfo> found;
            private Func<T, T, bool> eqComp;
    
            //optimization for IEnumerables that do not implement IList
            int patLen = -1;
            int seqLen = -1;
    
            /// <summary>Initializes a new instance of the <see cref="PatternSearch{T}" /> class.</summary>
            /// <param name="pattern">The pattern that will be searched for.</param>
            public PatternSearch(T[] pattern) : this(pattern, (x, y) => x.Equals(y)) { }
    
            /// <summary>
            /// Initializes a new instance of the <see cref="PatternSearch{T}"/> class with the specified equality comparer.
            /// </summary>
            /// <param name="pattern">The pattern to be searched for.</param>
            /// <param name="equalityComparer">The equality comparer to use for matching elements in the array.</param>
            public PatternSearch(T[] pattern, Func<T, T, bool> equalityComparer)
            {
                patLen = pattern.Length;
    
                if (pattern == null)
                    throw new ArgumentNullException("pattern", "The search pattern cannot be null.");
                if (equalityComparer == null)
                    throw new ArgumentNullException("equalityComparer", "The equality comparer cannot be null.");
    
                if (patLen <= 0)
                    throw new ArgumentException("pattern", "The pattern cannot be empty.");
    
                // assign the values
                this.pattern = pattern;
                found = new List<MatchInfo>();
                eqComp = equalityComparer;
            }
    
            /// <summary>
            /// Returns the start index of all occurrences of the search pattern within the specified array.
            /// </summary>
            /// <param name="seq">The larger sequence to find occurrences of the search pattern within.</param>
            public IEnumerable<int> Matches(IEnumerable<T> seq)
            {
                seqLen = seqLen == -1 ? seq.Count() : seqLen;
                return this.Matches(seq, 0, seqLen);
            }
    
            /// <summary>
            /// Returns the start index of all occurrences of the search pattern within the specified array.
            /// </summary>
            /// <param name="seq">The larger sequence to find occurrences of the search pattern within.</param>
            /// <param name="startIndex">The index in <paramref name="seq"/> to start searching at.</param>
            public IEnumerable<int> Matches(IEnumerable<T> seq, int startIndex)
            {
                seqLen = seqLen == -1 ? seq.Count() : seqLen;
                return this.Matches(seq, startIndex, seqLen);
            }
    
            /// <summary>
            /// Returns the start index of all occurrences of the search pattern within the specified array.
            /// </summary>
            /// <param name="seq">The larger sequence to find occurrences of the search pattern within.</param>
            /// <param name="count">The maximum number of items in <paramref name="seq"/> to match.</param>
            public IEnumerable<int> Matches(IEnumerable<T> seq, int startIndex, int count)
            {
                patLen = patLen == -1 ? pattern.Count() : patLen;
                seqLen = seqLen == -1 ? seq.Count() : seqLen;
                bool addedNew = false;
    
                var endPoint = Math.Min(seqLen, startIndex + count);
    
                if (seq == null ||                      // sequence cannot be null
                    seqLen < patLen ||                  // pattern cannot be longer than sequence
                    (endPoint - startIndex) < patLen)   // start to end cannot be less than pattern
                    yield break;
    
                for (int i = startIndex; i < endPoint; i++)
                {
                    addedNew = false;
    
                    // add the first item if a match is found
                    if (eqComp(seq.ElementAt(i), pattern.ElementAt(0)))
                    {
                        if (patLen == 1)
                            yield return i;
    
                        found.Add(new MatchInfo(i, 1));
                        addedNew = true;
                    }
    
                    // check incomplete matches
                    for (int m = found.Count - 1; m >= 0; m--)
                    {
                        //skip the last item added
                        if (addedNew && m == found.Count - 1)
                            continue;
    
                        var match = found[m];
    
                        // check incomplete matches
                        if ((i - match.StartIndex < patLen) &&
                            eqComp(seq.ElementAt(i), pattern.ElementAt(match.MatchLength)))
                        {
                            match.MatchLength += 1;
                            found[m] = match;
    
                            // determine if a complete match has been found
                            if (match.MatchLength == patLen)
                            {
                                yield return match.StartIndex;
                                found.RemoveAt(m);
                            }
                        }
                        else
                            found.RemoveAt(m);
                    }
                }
            }
    
        }
    }
