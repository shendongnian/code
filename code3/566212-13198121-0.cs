		public class GenericPropClass
		{
			public Type type;
			public object value;
			public string key;
		}
		[TestMethod]
		public void PropertySet()
		{
			var dict = new Dictionary<string, string>();
			var resultingList = new List<GenericPropClass>();
			// Specify the order with most "specific"/"wanted" type first and string last
			var order = new Type[] { typeof(DateTime), typeof(int), typeof(double), typeof(string) }; 
			foreach (var key in dict.Keys)
				foreach (var t in order)
				{
					try
					{
						var res = new GenericPropClass()
						{
							value = Convert.ChangeType(dict[key], t),
							key = key,
							type = t,
						};
						resultingList.Add(res);
						break;
					}
					catch (Exception)
					{
						// Just continue
					}
				}
		}
