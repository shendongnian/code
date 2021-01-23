    public class DocumentNumberWithinRangeComparer
    {
        public int? RangeFrom { get; set; }
        public int? RangeTo { get; set; }
        public DocumentNumberWithinRangeComparer(int? from, int? to)
        {
            RangeFrom = from;
            RangeTo = to;
        }
        public bool IncludeInResults(MyObject obj)
        {
            if (!RangeTo.HasValue || !RangeFrom.HasValue)
                return true;
            int docnumber;
            if (!Int32.TryParse(obj.Header.DocNumber, out docnumber))
                return false;
            return docnumber >= RangeFrom.Value && docnumber <= RangeTo.Value;
        }
    }
