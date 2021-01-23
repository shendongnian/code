        public IList<SearchCategoriesListDto> SearchPreviewCategories(String keywords)
        {
            string keywordsClean = keywords;
            keywordsClean = keywordsClean.ToUpper();
            keywordsClean = StringUtils.StringSimbolsRemove(keywordsClean, HeelpResources.StringSymbolsToCleanFrom, HeelpResources.StringSymbolsToCleanTo);
            string[] splitKeywords = keywordsClean.Split(new Char[] { ' ' });
            var searchQuery = _searchRepository.Query;
            foreach (string keyword in splitKeywords)
            {
                searchQuery = searchQuery.Where(p => p.SearchStandard.Contains(keyword));
            }
            var categoryQuery = _categoryRepository.Query;
            
            var query = from sq in searchQuery
                        join cq in categoryQuery on sq.CategoryId equals cq.Id
                        select new SearchCategoriesListDto { 
                            Name = cq.Name, 
                            SearchCount = searchQuery.Where(c => c.CategoryId == cq.Id).Count(), 
                            SearchPreviewControllerAction = cq.SearchPreviewControllerAction 
                        };
            var searchResults = query.Distinct().ToList();
           
            return searchResults;
