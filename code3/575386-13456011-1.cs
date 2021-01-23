            IList<IFilterBuilder> conditions = new List<IFilterBuilder>();
            if (termParameters != null)
                foreach (var termParameter in termParameters)
                    conditions.Add(FilterFactory.TermsFilter(ToCamelCaseNestedNames(termParameter.SearchField), termParameter.SearchValues));
            if (prefixParameters != null)
                foreach (var prefixParameter in prefixParameters)
                    conditions.Add(FilterFactory.PrefixFilter(ToCamelCaseNestedNames(prefixParameter.SearchField), prefixParameter.SearchValues.First().ToLowerInvariant()));
            var filters = FilterFactory.AndFilter();
            filters.Add(FilterFactory.AndFilter(conditions.ToArray()));
            MatchAllQueryBuilder matchAllQueryBuilder = new MatchAllQueryBuilder();
            FilteredQueryBuilder filteredQueryBuilder = new FilteredQueryBuilder(matchAllQueryBuilder, filters);
            SearchBuilder searchBuilder = new SearchBuilder();
            searchBuilder.Query(filteredQueryBuilder);
            searchBuilder.Size(maxResults);
 
