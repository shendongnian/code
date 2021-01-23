    public void SelectInto<SP_SearchEntity_Result, int>(int PageIndex, int PageSize, List<KeyValuePair<string, string>> SearchBy, List<KeyValuePair<string, System.Data.SqlClient.SortOrder>> SortBy, List<<SP_SearchEntity_Result> result1, List<int> result2)
    {
    	SqlCommand command = new SqlCommand("SP_SearchEntity");
    	command.CommandType = System.Data.CommandType.StoredProcedure;
    	command.Parameters.Add("PageIndex", SqlDbType.Int).Value = PageIndex;
    	command.Parameters.Add("SearchTableVar", SqlDbType.Xml).Value = SearchBy.ToXml();
    	
    	List<KeyValuePair<string, string>> SortByCastToString = // modify your ToDataTable method so you can pass a List<KeyValuePair<string, string>> for SortBy
    	command.Parameters.Add("SortTableVar", SqlDbType.Xml).Value = SortByCastToString.ToXml();
    	
    	ExecuteAs<SP_SearchEntity_Result, int>(command, result1, result2); 
    }
    
    public void SomeCallingMethod()
    {
    	List<SP_SearchEntity_Result> _results = new List<SP_SearchEntity_Result>{};
    	List<int> _counts = new List<int>{};
    	// ...
    	// setup your SearchBy and SortBy
    	// ...
    	
    	SelectInto<SP_SearchEntity_Result, int>(1, 20, SearchBy, SortBy, _results, _counts);
    }
