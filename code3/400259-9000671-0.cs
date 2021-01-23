	static class StrongReferencesLoader
	{
		public static void Load()
		{
			var ref1 = typeof(Class1); // ClassLibrary1.dll
			var ref2 = typeof(Class2); // ClassLibrary2.dll
		}
	}
