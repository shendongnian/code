        public static bool IsInRange(this DateTime testDate, DateRange range)
        {
            return range.Start <= testDate && range.End > testDate;
        }
        public static IEnumerable<DateRange> GroupConsecutive(this IEnumerable<DateRange> input)
        {
            var current = input.ToArray();
            var nextIndex = 0;
            //uses lookahead to figure out if gaps are consecutive.
            for (int i = 0; i < current.Length - 1; i++) {
                //If the next range is consecutive to the current, skip;
                if (!current[i].End.IsInRange(current[i + 1])) {
                    yield return new DateRange()
                                   {
                                       Start = current[nextIndex].Start,
                                       End = current[i].End
                                   };
                    nextIndex = i + 1;
                }
            }
            //If the last elements were consecutive, pull out the final item.
            if (nextIndex != current.Length) {
                yield return new DateRange()
                {
                    Start = current[nextIndex].Start,
                    End = current[current.Length - 1].End
                };
            }
        }
    }
