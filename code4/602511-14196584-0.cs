     new SolrBaseRepository.Instance<T>().Start();
     var solr = ServiceLocator.Current.GetInstance<ISolrOperations<T>>();
     var options = new QueryOptions
     {
         FilterQueries = new ISolrQuery[] { new SolrQueryByField("type", type) },
         ExtraParams = new Dictionary<string, string>{{"qt", "suggest"}},
     };
     var results = solr.Query(keyword, options);
     return results;
