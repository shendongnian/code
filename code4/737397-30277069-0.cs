    articles = solr.Query(sQuery, new QueryOptions
    {
       ExtraParams = new Dictionary<string, string> {
       {"fq", finalFacet},
    },
    Facet = new FacetParameters
    {
       Queries = new[] { new SolrFacetFieldQuery("content_type")}
    },
    Rows = 10
    Start = 1,
    });
