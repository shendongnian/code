	for(int n=0;n<100;n++)
	{
		var start=DateTime.UtcNow;
		var s=new HashSet<Dumb>(Enumerable.Range(0,n*10000).Select(_=>new Dumb()));
		Console.Write(n+" ");
		Console.WriteLine((int)((DateTime.UtcNow-start).TotalSeconds*10));
	}
