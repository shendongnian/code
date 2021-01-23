    static class FilterableEntensions{
        /// <summary>
        /// Filters a IFilterable enumeration
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static IQueryable<T> WithFiltering<T>(this IQueryable<T> query, string filter)  where T: IFilterable  {
            if (string.IsNullOrWhiteSpace(filter)) {
                //filter is empty, return original query
                return query;
            }
            else {
                //apply the filter
                return query.Where(x => x.FilterClause(filter));
            }
        }
    }
