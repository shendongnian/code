	private static TimeSpan RunInSerial(int inserts)
	{
		Stopwatch watch = new Stopwatch();
		watch.Start();
		using (var ctx = new DataClasses1DataContext())
		{
			for (int i = 0; i < inserts; i++)
			{
				ctx.Tables.InsertOnSubmit(new Table() { Number = i });
			}
			ctx.SubmitChanges();
		}
		watch.Stop();
		return watch.Elapsed;
	}
	
