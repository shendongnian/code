    	void Main()
		{
			List<C> cs = new List<C>();
			foreach(var i in Enumerable.Range(0,Int16.MaxValue*1000))
			{
				int modValue = Int16.MaxValue; //vary this value to see how the size of groups changes performance characteristics. Try 1, 5, 10, and very large numbers
				int j = i%modValue; 
				cs.Add(new C{I = i, J = j});
			}
			cs.Count ().Dump("Size of input array");
			
			TestGrouping(cs);
			TestDistinct(cs);
		}
		public void TestGrouping(List<C> cs)
		{
			Stopwatch sw = Stopwatch.StartNew();
			sw.Restart();
			var groupedCount  = cs.GroupBy (o => o.J).Select(s => s.First()).Count();
			groupedCount.Dump("num groups");
			sw.ElapsedMilliseconds.Dump("elapsed time for using grouping");
		}
		public void TestDistinct(List<C> cs)
		{
			Stopwatch sw = Stopwatch.StartNew();
			var distinctCount = cs.Distinct(new CComparerOnJ()).Count ();
			distinctCount.Dump("num distinct");
			sw.ElapsedMilliseconds.Dump("elapsed time for using distinct");
		}
		public class C
		{
			public int I {get; set;}
			public int J {get; set;}
		}
		public class CComparerOnJ : IEqualityComparer<C>
		{
			public bool Equals(C x, C y)
			{
				return x.J.Equals(y.J);
			}
			
			public int GetHashCode(C obj)
			{
				return obj.J.GetHashCode();
			}
		}
