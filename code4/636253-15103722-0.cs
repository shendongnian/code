    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    
    // Copyright (c) 2010 Alex Regueiro
    // Licensed under MIT license, available at <http://www.opensource.org/licenses/mit-license.php>.
    // Published originally at <http://blog.noldorin.com/2010/05/combinatorics-in-csharp/>.
    // Version 1.0, released 22nd May 2010.
    public static class CombinatoricsUtilities
    {
        // Error messages
        private const string errorMessageValueLessThanZero = "Value must be greater than zero, if specified.";
        private const string errorMessagesIndicesListInvalidSize = "List of indices must have same size as list of elements.";
    
        /// <summary>
        /// Gets all permutations (of a given size) of a given list, either with or without reptitions.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the list.</typeparam>
        /// <param name="list">The list of which to get permutations.</param>
        /// <param name="action">The action to perform on each permutation of the list.</param>
        /// <param name="resultSize">The number of elements in each resulting permutation; or <see langword="null"/> to get
        /// premutations of the same size as <paramref name="list"/>.</param>
        /// <param name="withRepetition"><see langword="true"/> to get permutations with reptition of elements;
        /// <see langword="false"/> to get permutations without reptition of elements.</param>
        /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/>. -or-
        /// <paramref name="action"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="resultSize"/> is less than zero.</exception>
        /// <remarks>
        /// The algorithm performs permutations in-place. <paramref name="list"/> is however not changed.
        /// </remarks>
        public static void GetPermutations<T>(this IList<T> list, Action<IList<T>> action, int? resultSize = null,
            bool withRepetition = false)
        {
            if (list == null)
                throw new ArgumentNullException("list");
            if (action == null)
                throw new ArgumentNullException("action");
            if (resultSize.HasValue && resultSize.Value <= 0)
                throw new ArgumentException(errorMessageValueLessThanZero, "resultSize");
            
            var result = new T[resultSize.HasValue ? resultSize.Value : list.Count];
            var indices = new int[result.Length];
            for (int i = 0; i < indices.Length; i++)
                indices[i] = withRepetition ? -1 : i - 1;
            
            int curIndex = 0;
            while (curIndex != -1)
            {
                indices[curIndex]++;
                if (indices[curIndex] == list.Count)
                {
                    indices[curIndex] = withRepetition ? -1 : curIndex - 1;
                    curIndex--;
                }
                else
                {
                    result[curIndex] = list[indices[curIndex]];
                    if (curIndex < indices.Length - 1)
                        curIndex++;
                    else
                        action(result);
                }
            }
        }
    
        /// <summary>
        /// Gets all combinations (of a given size) of a given list, either with or without reptitions.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the list.</typeparam>
        /// <param name="list">The list of which to get combinations.</param>
        /// <param name="action">The action to perform on each combination of the list.</param>
        /// <param name="resultSize">The number of elements in each resulting combination; or <see langword="null"/> to get
        /// premutations of the same size as <paramref name="list"/>.</param>
        /// <param name="withRepetition"><see langword="true"/> to get combinations with reptition of elements;
        /// <see langword="false"/> to get combinations without reptition of elements.</param>
        /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/>. -or-
        /// <paramref name="action"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="resultSize"/> is less than zero.</exception>
        /// <remarks>
        /// The algorithm performs combinations in-place. <paramref name="list"/> is however not changed.
        /// </remarks>
        public static void GetCombinations<T>(this IList<T> list, Action<IList<T>> action, int? resultSize = null,
            bool withRepetition = false)
        {
            if (list == null)
                throw new ArgumentNullException("list");
            if (action == null)
                throw new ArgumentNullException("action");
            if (resultSize.HasValue && resultSize.Value <= 0)
                throw new ArgumentException(errorMessageValueLessThanZero, "resultSize");
            
            var result = new T[resultSize.HasValue ? resultSize.Value : list.Count];
            var indices = new int[result.Length];
            for (int i = 0; i < indices.Length; i++)
                indices[i] = withRepetition ? -1 : indices.Length - i - 2;
    
            int curIndex = 0;
            while (curIndex != -1)
            {
                indices[curIndex]++;
                if (indices[curIndex] == (curIndex == 0 ? list.Count : indices[curIndex - 1] + (withRepetition ? 1 : 0)))
                {
                    indices[curIndex] = withRepetition ? -1 : indices.Length - curIndex - 2;
                    curIndex--;
                }
                else
                {
                    result[curIndex] = list[indices[curIndex]];
                    if (curIndex < indices.Length - 1)
                        curIndex++;
                    else
                        action(result);
                }
            }
        }
    
        /// <summary>
        /// Gets a specific permutation of a given list.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the list.</typeparam>
        /// <param name="list">The list to permute.</param>
        /// <param name="indices">The indices of the elements in the original list at each index in the permuted list.
        /// </param>
        /// <returns>The specified permutation of the given list.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/>. -or-
        /// <paramref name="indices"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="indices"/> does not have the same size as
        /// <paramref name="list"/>.</exception>
        public static IList<T> Permute<T>(this IList<T> list, IList<int> indices)
        {
            if (list == null)
                throw new ArgumentNullException("list");
            if (indices == null)
                throw new ArgumentNullException("indices");
            if (list.Count != indices.Count)
                throw new ArgumentException(errorMessagesIndicesListInvalidSize, "indices");
    
            var result = new T[list.Count];
            for (int i = 0; i < result.Length; i++)
                result[i] = list[indices[i]];
            return result;
        }
    }
