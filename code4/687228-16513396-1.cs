		static void Main(string[] args)
		{
			var props = typeof(MyClass).GetProperties();
			foreach (var propertyInfo in props)
			{
				if (propertyInfo.Name == "property")
				{
					var prop = propertyInfo;
				}
			}
		}
	}
	class MyClass
	{
		public static string property { get; set; }	
	}
