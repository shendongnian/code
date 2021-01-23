	public IEnumerable<Tuple<DateTime, DateTime>> Merge(IEnumerable<DateTime, DateTime>> ranges)
	{
		DateTime extentStart, extentEnd;
		using (var enumerator = ranges.OrderBy(r => r.Item1).GetEnumerator()) {
			bool recordsRemain = enumerator.MoveNext();
			while (recordsRemain)
			{
				extentStart = enumerator.Current.Item1;
				extentEnd = enumerator.Current.Item2;
				while ((recordsRemain = enumerator.MoveNext()) && enumerator.Current.Item1 < extentEnd)
				{
					if (enumerator.Current.Item2 > extentEnd)
					{
						extentEnd = enumerator.Current.Item2;
					}
				}
				yield return Tuple.Create(extentStart, extentEnd);
			}
		}
	}
