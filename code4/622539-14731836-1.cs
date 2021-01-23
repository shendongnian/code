    public class Picture
    {
        public int Id { get; set; }
        public string URL { get; set; }
    
        public int Ad_Id { get; set; }
        public virtual Ad Ad { get; set; }
    }
