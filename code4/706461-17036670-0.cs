	class ListTest
	{
		List<string> l = new List<string>();
		public List<string> GetList() { return l; }
		public void Add(string v) { l.Add(v); }
	}
	class Program
	{
		static void Main(string[] args)
		{
			ListTest t = new ListTest();
			t.Add("a"); t.Add("b"); t.Add("c"); t.Add("d");
			List<string> x1 = t.GetList();
			List<string> x2 = t.GetList().ToList();
			t.Add("e"); t.Add("f"); t.Add("g"); t.Add("h");
			List<string> y1 = t.GetList();
			List<string> y2 = t.GetList().ToList();
			Console.WriteLine("{0}, {1}", x1.Count, y1.Count);
			Console.WriteLine("{0}", string.Join(", ", x1));
			Console.WriteLine("{0}", string.Join(", ", y1));
		
			Console.WriteLine();
			Console.WriteLine("{0}, {1}", x2.Count, y2.Count);
			Console.WriteLine("{0}", string.Join(", ", x2));
			Console.WriteLine("{0}", string.Join(", ", y2));
		}
	}
