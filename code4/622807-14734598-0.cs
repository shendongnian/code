	void Main()
	{
		typeof(B).GetProperties()
		.Select((x,i) => new {
			Prop = x,
			DeclareOrder = i,
			InheritanceOrder = GetDepth(x.DeclaringType),
		})
		.OrderByDescending(x => x.InheritanceOrder)
		.ThenBy(x => x.DeclareOrder)
		.Dump();
	}
	
	public class A
	{
		public string W {get; set;}
	}
	
	public class B : A
	{
		public string X {get; set;}
		public string Y {get; set;}
		public string Z {get; set;}
	}
	
	static int GetDepth(Type t)
	{
		int depth = 0;
		while (t != null)
		{
			depth++;
			t = t.BaseType;
		}
		return depth;
	}
