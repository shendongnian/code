    partial void ArticleByProvider_PreprocessQuery(int? ProviderId, 
                                                   ref IQueryable<Article> query)
    {
         query.Where(x => x.ArticleProviders.Any(y => y.Provider.Id == ProviderId));
    }
