    public class SubsonicResource {
        public List<entry> NowPlaying { get; set; }
    }
    public class entry {
        public string Id { get; set; }
        public string Path { get; set; }
        public string Username { get; set; }
        ... 
    }
