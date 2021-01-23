		void Main()
	{
		string s = GetValue<string>("elementname");
		Guid? g = GetValue<Guid?>("elementname");
		Guid h = GetValue<Guid>("elementname");
		int? i = GetValue<int?>("elementname");
		int j = GetValue<int>("elementname");
		DateTime? d = GetValue<DateTime?>("elementname");
		DateTime e = GetValue<DateTime>("elementname");
		
		Console.WriteLine(s);
		Console.WriteLine(g);
		Console.WriteLine(h);
		Console.WriteLine(i);
		Console.WriteLine(j);
		Console.WriteLine(d);
		Console.WriteLine(e);
	}
	
	T GetValue<T>(string elementName)
	{
		return default(T);
	}
