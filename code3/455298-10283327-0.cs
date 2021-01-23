        public class PropertyExample
	{
		private readonly Dictionary<string, string> _properties;
		
		public string FirstName
		{
			get { return _properties["FirstName"]; }
			set { _properties["FirstName"] = value; }
		}
		public string LastName
		{
			get { return _properties["LastName"]; }
			set { _properties["LastName"] = value; }
		}
		public string this[string propertyName]
		{
			get { return _properties[propertyName]; }
			set { _properties[propertyName] = value; }
		}
		public PropertyExample()
		{
			_properties = new Dictionary<string, string>();
		}
	}
