    public static class EnumerableEx
    {
        public static IEnumerable<DateTime> DateRange(DateTime startDate, DateTime endDate, TimeSpan intervall)
        {
            for (DateTime d = startDate; d <= endDate; d += intervall) {
                yield return d;
            }
        }
    }
