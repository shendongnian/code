    public class Response
    {
        public string Meta { get; set; }
        public List<Venue> Venues { get; set; }
    }
    public class Venue
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Contact Contact { get; set; }
        public Location Location { get; set; }
        public string CanonicalUrl { get; set; }
        public Categories Categories { get; set; }
        public bool Verified { get; set; }
    }
