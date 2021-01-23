        public static PagingModel<T> Page<T>(this IEnumerable<T> query, int page, int count)
        {
            RavenQueryStatistics stats = null;
            if (page < 1)
                throw new ArgumentOutOfRangeException("Page is one-based and must be greater than zero");
            if (query is IRavenQueryable<T>)
            {
                var rQuery = (IRavenQueryable<T>)query;
                rQuery.Statistics(out stats);
            }
            var results = query
                .Skip((page - 1) * count)
                .Take(count)
                .ToArray();
            var total = stats == null ? query.Count() : stats.TotalResults;
            return new PagingModel<T>()
            {
                Page = page,
                Rows = results,
                TotalPages = (int)Math.Ceiling((double)total / (double)count)
            };
        }
