    public string PagetxtHeaderWordWideShipping { get; set; }
    public string PagetxtHeaderCurrency { get; set; }
    public string ComboSelectAll { get; set; }
    string pageTextsMaster = my json string reteived from db
    pageTextsMaster = pageTextsMaster ?? @"{"""":""""}"; //if pageTextsMaster isNull then I set an empty Json string.
		JObject o = JObject.Parse(pageTextsMaster);
		PagetxtHeaderWordWideShipping = (string)o.SelectToken("HeaderWordWideShipping", false); //Setting false will not throw an exception if the required value is not found
		PagetxtHeaderCurrency = (string)o.SelectToken("HeaderCurrency"); //false is default so I do not have to repeat it.
		ComboSelectAll = (string)o.SelectToken("ComboSelectAll");
