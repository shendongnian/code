	private static TimeSpan RunInParallel(int inserts)
	{
		Stopwatch watch = new Stopwatch();
		watch.Start();
		Parallel.For(0, inserts, new ParallelOptions() { MaxDegreeOfParallelism = 100 },
			(i) =>
			{
				using (var context = new DataClasses1DataContext())
				{
					context.Tables.InsertOnSubmit(new Table() { Number = i });
					context.SubmitChanges();
				}
			}
		);
		watch.Stop();
		return watch.Elapsed;
	}
