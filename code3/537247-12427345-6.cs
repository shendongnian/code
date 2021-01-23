    string[] columnNames = { "EmpName", "EmpID", "PhoneNo" };
    List<string[]> columnValues = new List<string[]>();
    for (int i = 0; i < 10; i++)
    {
    	columnValues.Add(new[] { "Ramesh", "12345", "12345" });
    }
    
    var testData = new List<ExpandoObject>();
    
    foreach (string[] columnValue in columnValues)
    {
    	dynamic data = new ExpandoObject();
    	for (int j = 0; j < columnNames.Count(); j++)
    	{
    		((IDictionary<String,Object>)data).Add(columnNames[j], columnValue[j]);
    	}
    	testData.Add(data);
    }
