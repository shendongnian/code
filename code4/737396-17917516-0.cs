    ISolrQueryResults<TestDocument> r = solr.Query("product_id:XXXXX", new QueryOptions {
        FacetQueries = new ISolrFacetQuery[] {
            new SolrFacetFieldQuery("category")
        }
    });
