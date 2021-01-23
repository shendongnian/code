    public static class DateRangeEnumerable
    {
        public static IEnumerable<DateTime> GetDates(this IEnumerable<DateRange> source)
        {
            var sortedSource = source.OrderBy(r => r.From);
            foreach (var range in sortedSource)
            {
                var d = range.From;
                while (d < range.To)
                {
                    yield return d;
                    d = d.AddDays(1);
                }
            }
        }
        public static IEnumerable<DateRange> GetRanges(this IEnumerable<DateTime> source)
        {
            var sortedSource = source.OrderBy(d => d);
            var enumerator = sortedSource.GetEnumerator();
            if (!enumerator.MoveNext())
                yield break;
            DateTime from = enumerator.Current;
            DateTime prev = from;
            while (true)
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        if (enumerator.Current == prev.AddDays(1))
                            prev = enumerator.Current;
                        else
                            break;
                    }
                    else
                    {
                        yield return new DateRange() { From = from, To = prev.AddDays(1) };
                        yield break;
                    }
                }
                yield return new DateRange() { From = from, To = prev.AddDays(1) };
                from = enumerator.Current;
                prev = enumerator.Current;
            }
        }
    }
