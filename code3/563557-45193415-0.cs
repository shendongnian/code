    private static IEnumerable<TimeRange> MergeTimeRanges(IEnumerable<TimeRange> ranges)
    {
        var mergedRanges = new List<TimeRange>();
        foreach (var range in ranges)
        {
            var overlapping = mergedRanges.Where(r => !(range.End < r.Start) && !(range.Start> r.End)).ToArray();
            if (overlapping.Length == 0)
            {
                mergedRanges.Add(range);
            }
            else
            {
                // add a new range made up of the overlapping ranges plus the new range, then delete the ovelapping ranges
                mergedRanges.Add(new TimeRange { Start = Math.Min(range.Start, overlapping.Min(r => r.Start)), End = Math.Max(range.End, overlapping.Max(r => r.End)) });
                foreach (var r in overlapping)
                    mergedRanges.Remove(r);
            }
        }
        return mergedRanges;
    }
