	//Grab original query as a DataServiceQuery
	DataServiceQuery<NetworkDevice> originalquery = (DataServiceQuery<NetworkDevice>) 
		(from x in NetworkDevices
		where	
		x.Type == "switch"
		select x);
	//Get the HTTP QueryString
	var querystr = (originalquery).RequestUri.Query;
	var filter = System.Web.HttpUtility.ParseQueryString(querystr)["$filter"];
	
	/* Create our own dynamic filter equivilant to 
		x.Name == "x" ||
		x.Name == "y" 
	*/
	string[] names = { "device1", "device2" };
	StringBuilder sb = new StringBuilder();
	sb.Append("(");
	foreach (string s in names)
	{
		sb.Append(String.Format("Name eq '{0}'",s));
		sb.Append(" or ");
	}
	sb.Remove(sb.Length - 4, 4);
	sb.Append(")");
	var dynamicfilter = sb.ToString();
	// If there was an original filter we'll add the dynamic one with AND , otherwise we'll just use the dynamicone
	var newfilter = dynamicfilter;
	if ( filter != null && filter.Trim() != string.Empty )
	{
	newfilter = filter + " and " + newfilter;
	}
	newfilter.Dump();
	
	
	var finalquery = 
		(from x in NetworkDevices.AddQueryOption("$filter",newfilter)
		select x).Take(50);
	
	finalquery.Dump();
		
