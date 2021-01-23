    [HttpPost]
    public string PostProcessData([FromBody]string parameters) {
		if (!String.IsNullOrEmpty(parameters)) {
			JObject json = JObject.Parse(parameters);
				
			// Code logic below
			// Can access params via json["paramName"].ToString();
		}
		return "";
	}
