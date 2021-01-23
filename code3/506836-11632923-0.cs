	class MyClass
	{  
		public string A{ get; set; }
		public string B{ get; set; }
		public string C{ get; set; }
		
		private static readonly int _propertyCount;
		
		static MyClass()
		{
			_propertyCount = typeof(MyClass).GetProperties().Count();
		}
	}
