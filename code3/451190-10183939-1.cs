    public class FeaturedReleases
    {
        public int id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public List<ReleaseArtist> artists { get; set; }
        public ReleaseImage images { get; set; }
    }
