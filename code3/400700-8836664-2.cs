    QueryParameters queryParameters = new QueryParameters();
    queryParameters.IPReference = "blabla";
    ...
    public cIPLink(QueryParameters queryParameters) 
    {
        if (queryParameters.CaseNo.HasValue) {
            ....
        }
        ...
    }
  
