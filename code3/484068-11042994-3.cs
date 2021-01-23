	void Main()
	{
		IEnumerable<IEnumerable<string>> cols=
			new string[][]
			{
				new string[]{"monkey", "frog", null, null, null, null},
				new string[]{null, null, null, null, "cat", "giraffe"},
				new string[]{null, null, null, "dog", "fish", null}
			};
		cols.MergeLeft().Dump();
		//gives: "monkey", "frog", null, "dog", "cat", "giraffe" 
	
		
	}
	
	static class Ex
	{
		public static IEnumerable<T> MergeLeft<T>
			(this IEnumerable<IEnumerable<T>> cols) where T:class
		{
			var maxItems = cols.Max(x => x.Count());
			var leftMerged = 
				cols
					.Aggregate(
						Enumerable.Repeat((T)null, maxItems),
						(acc,col) => acc.Zip(col, (a, b) => a ?? b));
			return leftMerged;
	
		}
	}
