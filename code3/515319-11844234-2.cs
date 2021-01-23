    public string FullAddress 
    { 
		get
		{
			string[] addressParts = { ReferenceKey, Country, County, Postcode, PremisesName }
			return string.Join(",", addressParts.Where(s => !string.IsNullOrEmpty(s)).ToArray());
		}  
    }
