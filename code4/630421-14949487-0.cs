    [XmlType("search")]
    public class EventSearch
    {
        public int total_items { get; set; }
        public int page_size { get; set; }
        public int page_count { get; set; }
        public int page_number { get; set; }
       // public int? page_items { get; set; }
        public string first_item { get; set; }
        public string last_item { get; set; }
        public string search_time { get; set; }
        public List<Event> events { get; set; }
    }
    [XmlType("event")]
    public class Event
    {
        [XmlAttribute("id")]
        public string id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public string start_time { get; set; }
        public string venue_id { get; set; }
        public string venue_url { get; set; }
        public string venue_name { get; set; }
        public string venue_address { get; set; }
        public string city_name { get; set; }
        public string region_name { get; set; }
        public string region_abbr { get; set; }
        public string postal_code { get; set; }
        public string country_name { get; set; }
        public string country_abbr { get; set; }
        public string country_abbr2 { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public List<Performer> performers { get; set; }
        public EventImage image { get; set; }
    }
    [XmlType("performer")]
    public class Performer
    {
        public string id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string short_bio { get; set; }
    }
    [XmlType("image")]
    public class EventImage
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public Image thumb { get; set; }
        public Image small { get; set; }
        public Image medium { get; set; }
    }
    [XmlType("thumb")]
    public class Image
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
