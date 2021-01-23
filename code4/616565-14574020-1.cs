    partial void ArticleByProvider_PreprocessQuery(int? ProviderId, 
                                                   ref IQueryable<Article> query)
    {
         query.Where(art => art.ArticleProviders
                                  .Any(artProv => artProv.Provider.Id == ProviderId));
    }
