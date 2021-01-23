    public class TimeRanges
    {
        private List<TimeRange> _mergedTimeRanges = new List<TimeRange>();
    
        public void Add(TimeRange timeRange)
        {
            if(!_mergedTimeRanges.Any(x=>x.IsOverLap(timeRange)))
            {
                _mergedTimeRanges.Add(timeRange);
                return;
            }
            while (_mergedTimeRanges.Any(x => x.IsOverLap(timeRange) && x!=timeRange))
            {
                TimeRange toMergeRange = _mergedTimeRanges.First(x => x.IsOverLap(timeRange));
                toMergeRange.Merge(timeRange);
                timeRange = toMergeRange;
            }
        }
    
        public IEnumerable<TimeRange> GetMergedRanges()
        {
            return _mergedTimeRanges;
        }
    }
