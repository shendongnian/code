	SortedSet<DateTime> splitdates = new SortedSet<DateTime>();
	foreach (var item in _list)
	{
		splitdates.Add(item.Period.Start);
		splitdates.Add(item.Period.End);
	}
	var list = splitdates.ToList();
	var ranges = new List<DateRange>();
	for (int i = 0; i < list.Count - 1; i++)
		ranges.Add(new DateRange() { Start = list[i], End = list[i + 1] });
	var result = from range in ranges
				 from c in _list
				 where c.Period.Intersect(range) != null
				 group c by range into r
				 select new Capacities(r.Key.Start, r.Key.End, r.Sum(a => a.Capacity));
