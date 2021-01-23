    /// <summary>
    /// Extension methods for lists (or lists of lists)
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Cache the generic method definition for <see cref="Descend{TElement, TResult}"/>
        /// </summary>
        private static readonly MethodInfo DescendMethod = new Func<List<object>, Func<object, object>, Func<IEnumerable<object>,object>, object>(Descend).Method.GetGenericMethodDefinition();
        /// <summary>
        /// Descends a potentially nested set of enumerables
        /// </summary>
        /// <typeparam name="TElement">The current enumerable type</typeparam>
        /// <typeparam name="TResult">The type of the result of the calling method</typeparam>
        /// <param name="set">The set of elements to work on</param>
        /// <param name="compute">The computation to perform on a single element</param>
        /// <param name="aggregate">The computation to perform on a collection of results from computations on single elements</param>
        /// <returns>The result of the aggregation of all the results from all levels of the set</returns>
        private static TResult Descend<TElement, TResult>(this List<TElement> set, Func<object, TResult> compute, Func<IEnumerable<TResult>, TResult> aggregate)
        {
            var elementType = typeof(TElement);
            if (elementType.IsGenericType && typeof(List<>) == elementType.GetGenericTypeDefinition())
            {
                var method = DescendMethod.MakeGenericMethod(elementType.GetGenericArguments()[0], typeof(TResult));
                if (ReferenceEquals(set, null))
                {
                    return aggregate(new[] { (TResult)method.Invoke(null, new object[] { default(TElement), compute, aggregate }) });
                }
                var results = set.Select(item => (TResult)method.Invoke(null, new object[] { item, compute, aggregate })).ToList();
                if (results.Count == 0)
                {
                    return aggregate(new[] { (TResult)method.Invoke(null, new object[] { default(TElement), compute, aggregate }) });
                }
                return aggregate(results);
            }
            return aggregate((set ?? new List<TElement>()).OfType<object>().Select(compute));
        }
        /// <summary>
        /// Walks down a set (possibly of sets) to determine its depth
        /// </summary>
        /// <typeparam name="TElement">The type of elements found in the top level set</typeparam>
        /// <param name="set">The set to walk down</param>
        /// <returns>The depth of the set</returns>
        public static int Depth<TElement>(this List<TElement> set)
        {
            return set.Descend(x => 0, x => x.FirstOrDefault() + 1);
        }
        /// <summary>
        /// Walks down a set (possibly of sets) to determine its depth
        /// </summary>
        /// <typeparam name="TElement">The type of elements found in the top level set</typeparam>
        /// <returns>The depth of the set</returns>
        public static int Depth<TElement>()
        {
            return Descend(default(List<TElement>), x => 0, x => x.FirstOrDefault() + 1);
        }
        /// <summary>
        /// Creates a string representation of a set (possibly of sets)
        /// </summary>
        /// <typeparam name="TElement">The type of elements found in the top level set</typeparam>
        /// <param name="set">The set to create the string representation of</param>
        /// <returns>A string representation of the set</returns>
        public static string Implode<TElement>(this List<TElement> set)
        {
            var result = set.Descend(x => x != null
                                              ? x.ToString()
                                              : null,
                                     x =>
                                     {
                                         var elements = x.Where(y => !ReferenceEquals(y, null)).ToList();
                                         if (elements.Count == 0)
                                         {
                                             return null;
                                         }
                                         return "(" + String.Join(",", elements) + ")";
                                     });
            if (result != null && result.Length > 2)
            {
                return result.Substring(1, result.Length - 2);
            }
            return result;
        }
    }
    class Program
    {
        private static void Main()
        {
            var tmp2 = new List<List<List<List<string>>>>();
            var tmp = new List<List<List<string>>>
                {
                    new List<List<string>>
                    {
                        new List<string>
                        {
                            "1",
                            "2",
                            "3"
                        },
                        new List<string>
                        {
                            "4"
                        }
                    },
                    new List<List<string>>
                    {
                        new List<string>
                        {
                            "5",
                            "6",
                            "7"
                        }
                    }
                };
            Console.WriteLine(ListExtensions.Depth<List<List<List<List<string>>>>>());
            Console.WriteLine(tmp2.Depth());
            Console.WriteLine(tmp2.Implode());
            Console.WriteLine(tmp.Depth());
            Console.WriteLine(tmp.Implode());
          
            Console.ReadLine();
        }
