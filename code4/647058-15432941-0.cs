        public static class SourceToResultRepository
        {
            public static IEnumerable<ResultClass> ConvertSourceToResult(this IQueryable<SourceClass> source)
            {
                return source.Select(s => new ResultClass
                {
                    ResultPropA = s.SourcePropA
                    //Add all other property transformations here
                });
            }
        }
