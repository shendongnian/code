    public class Picture
    {
        public int Id { get; set; }
        public string URL { get; set; }
    
        public virtual AdPicture AdPicture { get; set; }
    }
