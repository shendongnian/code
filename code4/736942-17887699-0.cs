    public class MyListDictionary
	{
		private Dictionary<string, List<string>> internalDictionary = new Dictionary<string,List<string>>();
		
		public void Add(string key, string value)
		{
			if (this.internalDictionary.ContainsKey(key))
			{
				List<string> list = this.internalDictionary[key];
				if (list.Contains(value) == false)
				{
					list.Add(value);
				}
			}
			else
			{
				List<string> list = new List<string>();
				list.Add(value);
				this.internalDictionary.Add(key, list);
			}
		}
	}
