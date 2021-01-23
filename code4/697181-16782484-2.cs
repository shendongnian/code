	// add reference to System.Web dll
	public Dictionary<string, string> GetQualities()
	{
		// assuming this code is in a controller
		var qualities = this.HttpContext.Cache["qualities"] as Dictionary<string, string>;
		if (qualities == null)
		{
			// LoadQualitiesFromXml() is the code above
			qualities = LoadQualitiesFromXml();
			this.HttpContext.Cache["qualities"] = qualities;
		}
		return qualities;
	}
