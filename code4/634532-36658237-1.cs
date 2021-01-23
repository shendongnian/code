    /// <summary>
    /// Extension method for sorting and filtering
    /// </summary>
    public static class SortingAndPagingHelper
    {
        public static IEnumerable<TSource> SortingAndPaging<TSource>(this IEnumerable<TSource> source, SortingAndPagingInfo sortingModal)
        {
            // Gets the coloumn name that sorting to be done on
            PropertyInfo propertyInfo = source.GetType().GetGenericArguments()[0].GetProperty(sortingModal.SortColumnName);
            // sorts by ascending if sort criteria is Ascending otherwise sorts descending
            return sortingModal.SortOrder == "Ascending" ? source.OrderByDescending(x => propertyInfo.GetValue(x, null)).Skip(sortingModal.PageSelected * sortingModal.PageSize).Take(sortingModal.PageSize)
                               : source.OrderBy(x => propertyInfo.GetValue(x, null)).Skip(sortingModal.PageSelected * sortingModal.PageSize).Take(sortingModal.PageSize);
        }
    }
