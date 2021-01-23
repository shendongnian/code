    public class Track  
    { 
        public Track()
        {
            this.PlaybackEvents = new HashSet<PlaybackEvent>();
        }
        // Primary key
        public string Id {get; set;} 
 
        // Navigation property
        public virtual ICollection<PlaybackEvent> PlaybackEvents { get; private set; } 
     }
