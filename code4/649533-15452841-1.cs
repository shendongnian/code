        public static IEnumerable<DateRange> FindGaps(IEnumerable<DateRange> baseCollection, IEnumerable<DateRange> testCollection)
        {
            var allBaseDates = baseCollection.SelectMany(o => o.GetDiscreetDates())
                .Distinct()
                .OrderBy(o => o.Ticks);
            var missingInTest = (from d in allBaseDates
                                 let inRange = testCollection.Any(o => d.IsInRange(o))
                                 where !inRange
                                 select d).ToArray();
            var gaps = missingInTest.Select(o => new DateRange() { Start = o, End = o.AddDays(1) });
            gaps = gaps.GroupConsecutive();
            return gaps;
        }
