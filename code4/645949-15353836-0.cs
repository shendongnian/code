    public class Location
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string zip { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
    
    public class Cover
    {
        public string cover_id { get; set; }
        public string source { get; set; }
        public int offset_y { get; set; }
        public int offset_x { get; set; }
    }
    
    public class RootObject
    {
        public string about { get; set; }
        public int checkins { get; set; }
        public string company_overview { get; set; }
        public string founded { get; set; }
        public bool is_published { get; set; }
        public Location location { get; set; }
        public string mission { get; set; }
        public string products { get; set; }
        public int talking_about_count { get; set; }
        public string username { get; set; }
        public string website { get; set; }
        public int were_here_count { get; set; }
        public string category { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public int likes { get; set; }
        public Cover cover { get; set; }
    }
