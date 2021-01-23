    public interface IMovie
    {
        string Director { get; set; }
        string Title { get; set; }
    }
    
    public class DvdMovie : IMovie
    {
        public string Director { get; set; }
        public string Title { get; set; }
    }
            
    public class BlueRayMovie : IMovie
    {
        public string Director { get; set; }
        public string Title { get; set; }
    }
