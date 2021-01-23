     var query = (from k in keywordQuery where splitKeywords.Contains(k.Name) 
                            join kac in keywordAdCategoryQuery on k.Id equals kac.Keyword_Id
                            join c in categoryQuery on kac.Category_Id equals c.Id
                            join a in adQuery on kac.Ad_Id equals a.Id
                            select new
                            {
                                Id = c.Id,
                                Name = c.Name,
                                SearchCount = keywordAdCategoryQuery.Where(s => s.Category_Id == c.Id).Where(s => s.Keyword_Id == k.Id).Distinct().Count(),
                                ListController = c.ListController,
                                ListAction = c.ListAction
                            }).Distinct().ToList();
        
            var searchResults = new CategoryListByBeywordsListDto();
        
        
    searchResults.CategoryListByKeywordsDetails = (from q in query select new           CategoryListByKeywordsDetailDto
    {
                            Id = q.Id,
                            Name = q.Name,
                            SearchCount = q.SearchCount,
                            ListController = q.ListController,
                            ListAction = q.ListAction
                        }).ToList();
