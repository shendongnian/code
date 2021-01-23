    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    namespace Demo
    {
        public static class Program
        {
            private static void Main(string[] args)
            {
                var unorderered = new[] { "a", "b", "c", "x", "y", "z" };
                var ordered = unorderered.OrderBy(compare); // Just need to specify the compare method!
            }
            // Each custom compare method must be written specially, as before:
            private static int compare(string x, string y)
            {
                if (x == y)
                    return 0;
                else
                {
                    //----------------------------
                    //beginning of custom ordering
                    var customPriority = new[] { "y", "x" };
                    if (customPriority.Any(a => a == x) && customPriority.Any(a => a == y)) //both in custom ordered array
                    {
                        if (Array.IndexOf(customPriority, x) < Array.IndexOf(customPriority, y))
                            return -1;
                        return 1;
                    }
                    else if (customPriority.Any(a => a == x)) //only one item in custom ordered array (and its x)                    
                        return -1;
                    else if (customPriority.Any(a => a == y)) //only one item in custom ordered array (and its y)                    
                        return 1;
                    //---------------------------
                    //degrade to default ordering
                    else
                        return string.Compare(x, y);
                }
            }
        }
        // The following classes only need to be written once:
        public static class EnumerableExt
        {
            /// <summary>
            /// Convenience method on IEnumerable{T} to allow passing of a
            /// Comparison{T} delegate to the OrderBy method.
            /// </summary>
            public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> list, Comparison<T> comparison)
            {
                Contract.Requires(list != null, "list can't be null.");
                Contract.Requires(comparison != null, "comparer can't be null.");
                return list.OrderBy(t => t, new ComparisonDelegator<T>(comparison));
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
                Contract.Requires(comparison != null);
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
    }
