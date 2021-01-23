    List<string> FacetFields = new List<string>{"field1", "field2", "fieldN"};
    
    qb.Facets(_facets => {
        FacetFields.ForEach(_ffield => 
            _facets.Terms(t => t
               .FacetName("FacetsFor" + _ffield)
               .Field(_ffield)
            )
        );
        // Return configured _facets as expected by qb.Facets
        return _facets;
    });
    // Get generated JSON
    string jsonQuery = qb.BuildBeautified();
