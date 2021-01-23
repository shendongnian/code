    public class SJSonModel
	{
		public SJSonModel(Dictionary<string, object> newFeature)
		{
			if (newFeature.ContainsKey("Name"))
			{
				Name = (string)newFeature["Name"];
			}
			if (newFeature.ContainsKey("isChecked"))
			{
				isChecked = bool.Parse((string)newFeature["isChecked"]);
			}
		}
		public string Name { get; set; }
		public bool isChecked { get; set; }
	}
	public class SJSonModelList
	{
		public SJSonModelList(List<SJSonModel> features, List<SJSonModel> menuItems )
		{
			Features = features;
			MenuItems = menuItems;
		}
		public List<SJSonModel> Features { get; set; }
		public List<SJSonModel> MenuItems { get; set; }
	}
