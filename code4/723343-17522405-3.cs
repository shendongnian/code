    public class SearchOptions
    {
        public string Q { get; set; }
        public TwitterGeoLocationSearch Geocode { get; set; }
        public string Lang { get; set; }
        public string Locale { get; set; }
        public TwitterSearchResultType? Resulttype { get; set; }
        public int? Count { get; set; }
        public long? SinceId { get; set; }
        public long? MaxId { get; set; }
        public bool? IncludeEntities { get; set; }
        public string Callback { get; set; }
    }	
