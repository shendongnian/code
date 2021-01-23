	class MyClass
	{  
		public string A { get; set; }
		public string B { get; set; }
		public string C { get; set; }
	
		public MyClass()
		{
		    int count = this.GetType().GetProperties().Count();
            // or
            count = typeof(MyClass).GetProperties().Count();
		}
	}
