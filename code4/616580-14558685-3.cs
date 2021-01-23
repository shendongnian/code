    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    namespace Demo
    {
        public static class Program
        {
            public static void Main()
            {
                var list = new List<Essay>
                {
                    new Essay {ID=1, Name="ccccc"},
                    new Essay {ID=2, Name="aaaa"},
                    new Essay {ID=3, Name="bbbb"},
                    new Essay {ID=4, Name="10"},
                    new Essay {ID=5, Name="1"},
                    new Essay {ID=6, Name="2"},
                    new Essay {ID=7, Name="1a"}                
                };
                var comp = new AlphanumComparator();
                list.Sort((lhs, rhs) => comp.Compare(lhs.Name, rhs.Name));
                foreach (var essay in list)
                {
                    Console.WriteLine("ID={0}, Name={1}", essay.ID, essay.Name);
                }
            }
        }
        public class Essay
        {
            public int ID
            {
                get;
                set;
            }
            public string Name
            {
                get;
                set;
            }
        }
        /// <summary>Extensions for IList{T}</summary>
    
        public static class ListExt
        {
            /// <summary> Sorts an IList{T} in place. </summary>
            public static void Sort<T>(this IList<T> list, Comparison<T> comparison)
            {
                ArrayList.Adapter((IList)list).Sort(new ComparisonDelegator<T>(comparison));
            }
        }
        /// <summary>
        /// Provides a mechanism for easily converting a Comparison&lt;&gt; delegate (or lambda) to an IComparer&lt;&gt;.
        /// This can be used for List.BinarySearch(), for example.
        /// </summary>
        /// <typeparam name="T">The type of items to be compared.</typeparam>
        public sealed class ComparisonDelegator<T>: IComparer<T>, IComparer
        {
            /// <summary>Create from a Comparison&lt;&gt; delegate.</summary>
            /// <param name="comparison">A Comparison&lt;&gt; delegate.</param>
            public ComparisonDelegator(Comparison<T> comparison)
            {
                this._comparison = comparison;
            }
            /// <summary>Implements the IComparer.Compare() method.</summary>
            public int Compare(T x, T y)
            {
                return _comparison(x, y);
            }
            /// <summary>Implements the IComparer.Compare() method.</summary>
            public int Compare(object x, object y)
            {
                return _comparison((T)x, (T)y);
            }
            /// <summary>Used to store the Comparison delegate.</summary>
            private readonly Comparison<T> _comparison;
        }
        /// <summary>
        /// Special class to sort strings "naturally", 
        /// but to place non-numeric items *before* numeric items.
        /// </summary>
        public class AlphanumComparator : IComparer
        {
            private enum ChunkType {Alphanumeric, Numeric};
            private bool InChunk(char ch, char otherCh)
            {
                ChunkType type = ChunkType.Alphanumeric;
                if (char.IsDigit(otherCh))
                {
                    type = ChunkType.Numeric;
                }
                if ((type == ChunkType.Alphanumeric && char.IsDigit(ch))
                    || (type == ChunkType.Numeric && !char.IsDigit(ch)))
                {
                    return false;
                }
                return true;
            }
            public int Compare(object x, object y)
            {
                String s1 = x as string;
                String s2 = y as string;
                if (s1 == null || s2 == null)
                {
                    return 0;
                }
                int thisMarker = 0, thisNumericChunk = 0;
                int thatMarker = 0, thatNumericChunk = 0;
                while ((thisMarker < s1.Length) || (thatMarker < s2.Length))
                {
                    if (thisMarker >= s1.Length)
                    {
                        return -1;
                    }
                    else if (thatMarker >= s2.Length)
                    {
                        return 1;
                    }
                    char thisCh = s1[thisMarker];
                    char thatCh = s2[thatMarker];
                    StringBuilder thisChunk = new StringBuilder();
                    StringBuilder thatChunk = new StringBuilder();
                    while ((thisMarker < s1.Length) && (thisChunk.Length==0 ||InChunk(thisCh, thisChunk[0])))
                    {
                        thisChunk.Append(thisCh);
                        thisMarker++;
                        if (thisMarker < s1.Length)
                        {
                            thisCh = s1[thisMarker];
                        }
                    }
                    while ((thatMarker < s2.Length) && (thatChunk.Length==0 ||InChunk(thatCh, thatChunk[0])))
                    {
                        thatChunk.Append(thatCh);
                        thatMarker++;
                        if (thatMarker < s2.Length)
                        {
                            thatCh = s2[thatMarker];
                        }
                    }
                    int result = 0;
                    // If both chunks contain numeric characters, sort them numerically
                    if (char.IsDigit(thisChunk[0]) && char.IsDigit(thatChunk[0]))
                    {
                        thisNumericChunk = Convert.ToInt32(thisChunk.ToString());
                        thatNumericChunk = Convert.ToInt32(thatChunk.ToString());
                        if (thisNumericChunk < thatNumericChunk)
                        {
                            result = -1;
                        }
                        if (thisNumericChunk > thatNumericChunk)
                        {
                            result = 1;
                        }
                    }
                    else if (char.IsDigit(thisChunk[0]) && !char.IsDigit(thatChunk[0]))
                    {
                        return 1; // Ensure that non-numeric sorts before numeric.
                    }
                    else if (!char.IsDigit(thisChunk[0]) && char.IsDigit(thatChunk[0]))
                    {
                        return -1;  // Ensure that non-numeric sorts before numeric.
                    }
                    else
                    {
                        result = thisChunk.ToString().CompareTo(thatChunk.ToString());
                    }
                    if (result != 0)
                    {
                        return result;
                    }
                }
                return 0;
            }
        }
    }
