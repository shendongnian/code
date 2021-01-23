    var entities = ItemStoreManager<Category>.Search(keyword); 
    new SolrBaseRepository.Instance<T>().Start();
    var solr = ServiceLocator.Current.GetInstance<ISolrOperations<T>>();
    var options = new QueryOptions{ 
      FilterQueries = new ISolrQuery[] { new SolrQueryByField("type","Item")}};
    var results = solr.Query(keyword, options);
