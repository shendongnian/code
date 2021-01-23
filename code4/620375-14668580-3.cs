    public class Range
    {
        public int Start { get; set; }
        public int End { get; set; }
    }
    public List<Range> _fts = new List<Range>();
    _fts.Add(new Range {Start = LR[I].start, End = LR[I].end} );
