    MultiFieldSearchParam parameters = new MultiFieldSearchParam();
    
    parameters.Database = "web";
    parameters.InnerCondition =  QueryOccurance.Should;
    parameters.FullTextQuery = searchTerm;        
    parameters.TemplateIds = array of pipe seperated ID's
    var refinements = Filters.Select(item => new MultiFieldSearchParam.Refinement(item.Value, item.Key.ToString())).ToList();
    
    parameters.Refinements = refinements;
