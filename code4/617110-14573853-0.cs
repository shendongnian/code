	private class RecordPropertyJavaScriptConverter : JavaScriptConverter
	{
		private static readonly Type[] _supportedTypes = new[]
		{
			typeof(record_group)
		};
		public override IEnumerable<Type> SupportedTypes
		{
			get { return _supportedTypes; }
		}
		public override object Deserialize(IDictionary<string, object> dictionary,
											Type type,
											JavaScriptSerializer serializer)
		{
			if (type == typeof(record_group))
			{
				record_group obj = new record_group();
				var kvp = dictionary.Single();
				obj.Key = kvp.Key;
				obj.Values = serializer.ConvertToType<IEnumerable<object>>(kvp.Value);
				return obj;
			}
			return null;
		}
		public override IDictionary<string, object> Serialize(
				object obj,
				JavaScriptSerializer serializer)
		{
			var dataObj = obj as record_group;
			if (dataObj != null)
			{
				return new Dictionary<string, object>
				{
					{dataObj.Key,  dataObj.Values}
				};
			}
			return new Dictionary<string, object>();
		}
	}
    
