    public class PlaybackEvent 
    {  
        // Primary key
        public string Id {get; set;}  
  
        // Foreign key
        public string Track_Id { get; set; }  
        // Navigation property
        public virtual Track Track { get; set; }
    }  
