    var query = _session.Advanced.LuceneQuery<Product>("ProductIndex")
                                .WaitForNonStaleResults()
                                .Search("CategoryNameAnalyzed", "heels");
	var products = query.ToList();
	var facets = query.ToFacets("facets/ProdctFacets");
	
