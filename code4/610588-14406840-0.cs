	//Usage: GetProperties(jObject).Dump();
	public static object GetProperties(object o)
	{
		JObject j = o as JObject;
		if(j == null)
		{
			return o.ToString();
		}
		return j.Properties().ToDictionary(p=>p.Name,p=>GetProperties(p.Value));
	}
