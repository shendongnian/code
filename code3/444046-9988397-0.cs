    public class FeaturedReleases
    {
        public int id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public ReleaseImage images { get; set; }
    }
    public class ReleaseImage
    {
        public ReleaseSmall small { get; set; }
        public ReleaseMedium medium { get; set; }
        public ReleaseLarge large { get; set; }
    }
