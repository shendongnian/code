    public class Picture
    {
        // Primary properties
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Filename { get; set; }
        public string URL { get; set; }
    
        // Navigation properties
        //public int PictureType_Id { get; set; }
        public virtual PictureType PictureType { get; set; }
        //public int Ad_Id { get; set; }
        public virtual Ad Ad { get; set; }
    }
