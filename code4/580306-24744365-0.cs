    private List<SearchResponse> SearchDirectory(string distinguishedName, string searchFilter, System.DirectoryServices.Protocols.SearchScope searchScope, params string[] attributeList)
    {
    	List<SearchResponse> result = new List<SearchResponse>();
    	SearchResponse response = null;
    	int maxResultsToRequest = 100;
    	try
    	{
    		PageResultRequestControl pageRequestControl = new PageResultRequestControl(maxResultsToRequest);
    
    		// used to retrieve the cookie to send for the subsequent request
    		PageResultResponseControl pageResponseControl;
    		SearchRequest searchRequest = new SearchRequest(distinguishedName, searchFilter, searchScope, attributeList);
    		searchRequest.Controls.Add(pageRequestControl);
    
    		while (true)
    		{
    			response = (SearchResponse)connection.SendRequest(searchRequest);
    			result.Add(response);
    			pageResponseControl = (PageResultResponseControl)response.Controls[0];
    			if (pageResponseControl.Cookie.Length == 0)
    				break;
    			pageRequestControl.Cookie = pageResponseControl.Cookie;
    		}
    	}
    	catch (Exception e)
    	{
    		// do something with the error
    		
    	}
    	return result;
    }
