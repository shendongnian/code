    /// <summary>
    /// Searches the entire sorted IList{T} for an element using the specified comparer 
    /// and returns the zero-based index of the element.
    /// </summary>
    /// <typeparam name="TItem">The type of the item.</typeparam>
    /// <typeparam name="TSearch">The type of the searched item.</typeparam>
    /// <param name="list">The list to be searched.</param>
    /// <param name="value">The value to search for.</param>
    /// <param name="comparer">The comparer that is used to compare the value with the list items.</param>
    /// <returns>
    /// The zero-based index of item in the sorted IList{T}, if item is found; 
    /// otherwise, a negative number that is the bitwise complement of the index of the next element that is larger than item,
    /// or - if there is no larger element - the bitwise complement of Count.
    /// </returns>
    public static int BinarySearch<TItem, TSearch>(this IList<TItem> list, TSearch value, Func<TSearch, TItem, int> comparer)
    {
        Contract.Requires(list != null);
        Contract.Requires(comparer != null);
        int lower = 0;
        int upper = list.Count - 1;
        while (lower <= upper)
        {
            int middle = lower + (upper - lower) / 2;
            int comparisonResult = comparer(value, list[middle]);
            if (comparisonResult < 0)
            {
                upper = middle - 1;
            }
            else if (comparisonResult > 0)
            {
                lower = middle + 1;
            }
            else
            {
                return middle;
            }
        }
        return ~lower;
    }
