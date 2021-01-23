    void GetCSVFromRemoteUrl(string url)
    {
    	HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
    	HttpWebResponse response = request.GetResponse() as HttpWebResponse;
    
    	using (CsvReader csvReader = new CsvReader(response.GetResponseStream(), true))
    	{
    		int fieldCount = csvReader.FieldCount;
    		string[] headers = csvReader.GetFieldHeaders();
    
    		while (csvReader.ReadNextRecord())
    		{
    			//Do work with CSV file data here
    		}
    	}
    	
    }
