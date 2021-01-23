        /// <summary>
        /// The sorted page list is the main way of retrieving a subset of data.  
        /// </summary>
        /// <typeparam name="TSortKey"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="sortBy"></param>
        /// <param name="descending"></param>
        /// <param name="skipRecords"></param>
        /// <param name="takeRecords"></param>
        /// <returns></returns>
        public virtual IQueryable<TPoco> GetSortedPageList<TSortKey>(Expression<Func<TPoco, bool>> predicate,
                                         Expression<Func<TPoco, TSortKey>> sortBy, bool descending, int skipRecords, int takeRecords) {
            if (!descending) {
                return Context.Set<TPoco>().Where<TPoco>(predicate)
                         .OrderBy(sortBy)
                        .Skip(skipRecords)
                        .Take(takeRecords);
            }
            return
                Context.Set<TPoco>().Where<TPoco>(predicate)
                    .OrderByDescending(sortBy)
                    .Skip(skipRecords)
                    .Take(takeRecords);
        }
