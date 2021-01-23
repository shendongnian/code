	public class MyType
	{
		public int test;
		public string Name { get; set; }
		public int Age { get; set; }
		public int ReadOnly { get { return 1; } }
		public int SetOnly { set {} }
	}
