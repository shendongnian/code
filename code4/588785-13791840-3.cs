    public interface IMovie
    {
        string Director { get; set; }
        string Title { get; set; }
    }
    // TODO: Make immutable. 
    // Make setter private and introduce parametrized constructor    
    public class DvdMovie : IMovie
    {
        public string Director { get; set; }
        public string Title { get; set; }
    }
    // TODO: Make immutable. 
    // Make setter private and introduce parametrized constructor                
    public class BlueRayMovie : IMovie
    {
        public string Director { get; set; }
        public string Title { get; set; }
    }
