	Dictionary<string, List<string>> idsAndTheirNames = new Dictionary<string, List<string>>();
	try
	{
		var ajsonObject = JsonConvert.DeserializeObject<dynamic>(JSONstring);
		foreach (var child in ajsonObject.Children())
		{
			foreach (var product in child.Children())
			{
				var categories = product.categories.analysis;
				foreach (var category in categories.Children())
				{
					foreach (var subcat in category)
					{
						List<string> name = idsAndTheirNames[(string)subcat.id]; //e.g., "9001"
						if (name == null) name = new List<string>();
						name.Add(category.Name); //e.g., "Abbbb"
						idsAndTheirNames[(string)subcat.id] = name; //"9001" -> ["Abbbb", "Acccc", etc.]
						System.Diagnostics.Debug.WriteLine((string)category.Name);  //"Abbbb"
						System.Diagnostics.Debug.WriteLine((string)subcat.name);	//"Chapter B"
						System.Diagnostics.Debug.WriteLine((string)subcat.id);		//"9001"
					}
				}
			}
		}
	}
	catch (Exception ex)
	{
		System.Diagnostics.Debug.WriteLine("JSON ERROR: " + ex.Message);
	}
