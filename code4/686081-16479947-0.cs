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
    		public static void GetCombinations<T>(IList<T> list, Action<IList<T>> action, int? resultSize = null,
    			bool withRepetition = false)
    		{
    			if (list == null)
    				throw new ArgumentNullException("list");
    			if (action == null)
    				throw new ArgumentNullException("action");
    			if (resultSize.HasValue && resultSize.Value <= 0)
    				throw new ArgumentException("error", "resultSize");
    
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
