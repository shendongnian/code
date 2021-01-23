	public class Product
	{
		private Type _type;
		public Product()
		{
			fields = new Dictionary<string, object>();
			_type = GetType();
		}
		public string id { get; set; }
		public string name { get; set; }
		public Dictionary<string, object> fields { get; set; }
		public void SetProperty(string key, object value)
		{
			var propertyInfo = _type.GetProperty(key);
			if (null == propertyInfo)
			{
				fields.Add(key,value);
				return;
			}
			propertyInfo.SetValue(this, value.ToString());
		}
	}
	...
	private const string JsonTest = "{\"id\":7908,\"name\":\"product name\",\"_unknown_field_name_1\":\"some value\",\"_unknown_field_name_2\":\"some value\"}";
	var product = new Product();
	var data = JObject.Parse(JsonTest);
	foreach (var item in data)
	{
		product.SetProperty(item.Key, item.Value);
	}
