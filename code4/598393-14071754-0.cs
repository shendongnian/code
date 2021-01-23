	for(int n=0;n<100;n++)
	{
		var start=DateTime.UtcNow;
		var s=new HashSet<Dumb>();
		for(int i=0;i<n*10000;i++)
			s.Add(new Dumb());
		Console.Write(n+" ");
		Console.WriteLine((int)((DateTime.UtcNow-start).TotalSeconds*10));
	}
