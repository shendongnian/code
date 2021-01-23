    [Table("map_ratings_vsh")]
    public class MapRatingsVSH : MapRatingsBase {}
    
    [Table("map_ratings_jump")]
    public class MapRatingsJump : MapRatingsBase {}
    public class MapRatingsBase
    {
        public string SteamID { get; set; }
    
        public string Map { get; set; }
    
        public int Rating { get; set; }
    
        [Column( "rated" )]
        public DateTime Time { get; set; }
    }
