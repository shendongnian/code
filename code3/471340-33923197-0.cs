	void Main()
	{
		// http://stackoverflow.com/questions/10718364/check-if-t-inherits-or-implements-a-class-interface
		
		var b1 = new BaseClass1();
		
		var c1 = new ChildClass1();
		var c2 = new ChildClass2();
		var nb = new nobase();
		
		Util.HorizontalRun(
			"baseclass->baseclass,child1->baseclass,baseclass->child1,child2->baseclass,baseclass->child2,nobase->baseclass,baseclass->nobase",
			b1.IsAssignableFrom(typeof(BaseClass1)),
			c1.IsAssignableFrom(typeof(BaseClass1)),
			b1.IsAssignableFrom(typeof(ChildClass1)),
			c2.IsAssignableFrom(typeof(BaseClass1)),
			b1.IsAssignableFrom(typeof(ChildClass2)),
			nb.IsAssignableFrom(typeof(BaseClass1)),
			b1.IsAssignableFrom(typeof(nobase))
			).Dump("Results");
		
		var results = new List<string>();
		string test;
		
		test = "c1 = b1";
		try {
			c1 = (ChildClass1) b1;
			results.Add(test);
		} catch { results.Add("FAIL: " + test); }
		
		test = "b1 = c1";
		try {
			b1 = c1;
			results.Add(test);
		} catch { results.Add("FAIL: " + test); }
		
		test = "c2 = b1";
		try {
			c2 = (ChildClass2) b1;
			results.Add(test);
		} catch { results.Add("FAIL: " + test); }
		test = "b1 = c2";
		try {
			b1 = c2;
			results.Add(test);
		} catch { results.Add("FAIL: " + test); }
				
		results.Dump();
	}
	
	// Define other methods and classes here
	public static class exts {
		public static bool IsAssignableFrom<T>(this T entity, Type baseType) {
			return typeof(T).IsAssignableFrom(baseType);
		}
	}
	
	
	class BaseClass1 {
		public int id;
	}
	
	class ChildClass1 : BaseClass1 {
		public string name;
	}
	
	class ChildClass2 : ChildClass1 {
		public string descr;
	}
	
	class nobase {
		public int id;
		public string name;
		public string descr;
	}
