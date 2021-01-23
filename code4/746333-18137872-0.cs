	public static IEnumerable<string> SplitEvery(this string s, int n) {
		var enumerators = Enumerable.Repeat(s.GetEnumerator(), n);
		while (true) {
			var chunk = string.Concat(enumerators
				.Where(e => e.MoveNext())
				.Select(e => e.Current));
			if (chunk == "") yield break;
			yield return chunk;
		}
	}
