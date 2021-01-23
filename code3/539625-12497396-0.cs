    /// <summary>
        /// Merges two sequences by using the specified predicate function to determine when to iterate the second enumerbale.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> that contains merged elements of two input sequences.
        /// </returns>
        /// <param name="larger">The first sequence to merge.</param><param name="smaller">The second sequence to merge.</param>
        /// <param name="resultSelector">A function that specifies how to merge the elements from the two sequences (a flag is passed into the dunction to notify when elements of the second source are exhausted.</param>
        /// <typeparam name="TFirst">The type of the elements of the first input sequence.</typeparam>
        /// <typeparam name="TSecond">The type of the elements of the second input sequence.</typeparam>
        /// <typeparam name="TResult">The type of the elements of the result sequence.</typeparam>
        public static IEnumerable<TResult> ConditionalZip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> larger, IEnumerable<TSecond> smaller, Func<TFirst, TSecond, bool> predicate, Func<TFirst, TSecond, bool, TResult> resultSelector)
        {
            if (larger == null)
                throw new ArgumentNullException("larger");
            if (smaller == null)
                throw new ArgumentNullException("smaller");
            if (resultSelector == null)
                throw new ArgumentNullException("resultSelector");
            else
                return ConditionalZipIterator(larger, smaller, predicate, resultSelector);
        }
        private static IEnumerable<TResult> ConditionalZipIterator<TFirst, TSecond, TResult>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, bool> predicate, Func<TFirst, TSecond, bool, TResult> resultSelector)
        {
            var secondIsFinished = false;
            var isFirstRun = true;
            TSecond currentSecond = default(TSecond);
            using (IEnumerator<TFirst> enumerator1 = first.GetEnumerator())
            {
                using (IEnumerator<TSecond> enumerator2 = second.GetEnumerator())
                {
                    while (enumerator1.MoveNext())
                        {
                            if (isFirstRun || (!secondIsFinished && predicate(enumerator1.Current, currentSecond)))
                            {
                                isFirstRun = false;
                                if (!enumerator2.MoveNext())
                                {
                                    secondIsFinished = true;
                                }
                                currentSecond = secondIsFinished ? default(TSecond) : enumerator2.Current;
                            }
                            yield return resultSelector(enumerator1.Current, currentSecond, secondIsFinished);
                        }
                }
            }
        }
