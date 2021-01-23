		static bool TryFiveTimes()
		{
			return Observable.Interval(TimeSpan.FromSeconds(1))
				.Take(5)
				.Select(_ => Fn())
				.Scan(false, (curr, prev) => curr || prev)
				.FirstOrDefault(v => v);
		}
		static int counters = 0;
		static bool Fn()
		{
			counters++;
			Console.WriteLine(counters);
			return counters > 2;
		}
