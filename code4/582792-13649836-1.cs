	void LoadJSONData()
	{
		string testData = "{ \"Name\":\"John Smith\", \"Age\":42, \"Parent\": { \"Name\":\"Brian Smith\", \"Age\":65, \"Parent\": { \"Name\":\"James Smith\", \"Age\":87, } } }";
		ExpandoObject dataObj = JsonConvert.DeserializeObject<ExpandoObject>(testData, new ExpandoObjectConverter());
		// Grab the parent object directly (if it exists) and treat as ExpandoObject
		var parentElement = dataObj.Where(el => el.Key == "Parent").FirstOrDefault();
		if (parentElement.Value != null && parentElement.Value is ExpandoObject)
		{
			ExpandoObject parentObj = (ExpandoObject)parentElement.Value;
			// do something with the parent object...
		}
		// Alternately, iterate through the properties of the expando
		foreach (var property in (IDictionary<String, Object>)dataObj)
		{
			if (property.Key == "Parent" && property.Value != null && property.Value is ExpandoObject)
			{
				foreach (var parentProp in (ExpandoObject)property.Value)
				{
					// do something with the properties in the parent expando
				}
			}
		}
	}
