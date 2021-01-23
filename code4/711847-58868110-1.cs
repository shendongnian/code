        /// <summary>
        /// Find an index of a first element that satisfies <paramref name="match"/>
        /// </summary>
        /// <typeparam name="T">Type of elements in the source collection</typeparam>
        /// <param name="this">This</param>
        /// <param name="match">Match predicate</param>
        /// <returns>Zero based index of an element. -1 if there is not such matches</returns>
        public static int IndexOf<T>(this IList<T> @this, Predicate<T> match)
        {
            @this.ThrowIfArgumentIsNull();
            match.ThrowIfArgumentIsNull();
            for (int i = 0; i < @this.Count; ++i)
                if (match(@this[i]))
                    return i;
            return -1;
        }
        /// <summary>
        /// Replace the first occurance of an oldValue which satisfies the <paramref name="removeByCondition"/> by a newValue
        /// </summary>
        /// <typeparam name="T">Type of elements of a target list</typeparam>
        /// <param name="this">Source collection</param>
        /// <param name="removeByCondition">A condition which decides is a value should be replaced or not</param>
        /// <param name="newValue">A new value instead of replaced</param>
        /// <returns>This</returns>
        public static IList<T> Replace<T>(this IList<T> @this, Predicate<T> replaceByCondition, T newValue)
        {
            @this.ThrowIfArgumentIsNull();
            removeByCondition.ThrowIfArgumentIsNull();
            int index = @this.IndexOf(replaceByCondition);
            if (index != -1)
                @this[index] = newValue;
            return @this;
        }
        /// <summary>
        /// Replace all occurance of values which satisfy the <paramref name="removeByCondition"/> by a newValue
        /// </summary>
        /// <typeparam name="T">Type of elements of a target list</typeparam>
        /// <param name="this">Source collection</param>
        /// <param name="removeByCondition">A condition which decides is a value should be replaced or not</param>
        /// <param name="newValue">A new value instead of replaced</param>
        /// <returns>This</returns>
        public static IList<T> ReplaceAll<T>(this IList<T> @this, Predicate<T> replaceByCondition, T newValue)
        {
            @this.ThrowIfArgumentIsNull();
            removeByCondition.ThrowIfArgumentIsNull();
            for (int i = 0; i < @this.Count; ++i)
                if (replaceByCondition(@this[i]))
                    @this[i] = newValue;
            return @this;
        }
