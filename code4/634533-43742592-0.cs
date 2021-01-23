        /// Used to indicate the sort order.
        /// </summary>
        public enum SortOrder
        {
            /// <summary>
            /// Indicates whether the order is ascending.
            /// </summary>
            Ascending = 0,
    
            /// <summary>
            /// Indicates whether the order is descending.
            /// </summary>
            Descending = 1,
    
            /// <summary>
            /// Indicates whether the order is neutral.
            /// </summary>
            Neutral = 2
        }
    
        /// <summary>
        /// DTO for sorting and paging
        /// </summary>
        public class FilterProperties
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="FilterProperties"/> class.
            /// </summary>
            public FilterProperties()
            {
                // parameterless constructor
            }
    
            /// <summary>
            /// Initializes a new instance of the <see cref="FilterProperties"/> class.
            /// </summary>
            /// <param name="sortColumnName">column name of sorting.</param>
            /// <param name="sortOrder">order of the sorting</param>
            /// <param name="pageSize">items in the page.</param>
            /// <param name="filterValue">value of the filter.</param>
            /// <param name="pageselected">current page selected.</param>
            public FilterProperties(string sortColumnName, SortOrder sortOrder, int pageSize, string filterValue = "All", int pageselected = 0)
            {
                this.SortColumnName = sortColumnName;
                this.SortOrder = sortOrder;
                this.PageSize = pageSize;
                this.PageSelected = pageselected;
                this.FilterValue = filterValue;
            }
    
            /// <summary>
            /// Gets or sets the filter column name
            /// </summary>
            public string FilterColumnName { get; set; }
    
            /// <summary>
            /// Gets or sets the filter value
            /// </summary>
            public string FilterValue { get; set; }
    
            /// <summary>
            /// Gets or sets the sort field name.
            /// </summary>
            public string SortColumnName { get; set; }
    
            /// <summary>
            /// Gets or sets the sort direction.
            /// </summary>
            public SortOrder SortOrder { get; set; }
    
            /// <summary>
            /// Gets or sets the page size.
            /// </summary>
            [Obsolete("Use RecordCount instead (remove this)")]
            public int PageSize { get; set; }
    
            /// <summary>
            /// Gets or sets the current page index.
            /// </summary>
            [Obsolete("Use StartRecord instead (remove this)")]
            public int PageSelected { get; set; }
            
            /// <summary>
            /// Gets or sets the zero-based index of the starting record to return in
            /// the filtered result set.         
            /// </summary>
            public int StartRecord { get; set; }
    
            /// <summary>
            /// Gets or sets the number of records to return in the filtered result set.         
            /// </summary>
            public int RecordCount { get; set; }
        }
    }
    
    Extension Method for sorting and paging
    public static class SortingAndPagingHelper
        {
            /// <summary>
            /// Returns the list of items of type on which method called
            /// </summary>
            /// <typeparam name="TSource">This helper can be invoked on IEnumerable type.</typeparam>
            /// <param name="source">instance on which this helper is invoked.</param>
            /// <param name="sortingModal">Page no</param>
            /// <returns>List of items after query being executed on</returns>
            public static IEnumerable<TSource> SortingAndPaging<TSource>(
                this IEnumerable<TSource> source, 
                FilterProperties sortingModal)
            {
                // Is there any sort column supplied?
                IEnumerable<TSource> data = source;
                if (!string.IsNullOrEmpty(sortingModal.SortColumnName))
                {
                    // Gets the coloumn name that sorting to be done on
                    PropertyInfo propertyInfo =
                        data.GetType().GetGenericArguments()[0].GetProperty(sortingModal.SortColumnName);
    
                    // Define the sorting function
                    data = sortingModal.SortOrder == SortOrder.Ascending
                        ? data.OrderBy(x => propertyInfo.GetValue(x, null))
                        : data.OrderByDescending(x => propertyInfo.GetValue(x, null));
                }
    
                // Apply paging to (sorted) data
                return sortingModal.RecordCount > 0
                    ? data.Skip(sortingModal.StartRecord).Take(sortingModal.RecordCount)
                    : data.Skip((sortingModal.PageSelected - 1) * sortingModal.PageSize).Take(sortingModal.PageSize);
            }
        }
