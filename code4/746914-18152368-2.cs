    public class Episodes
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
    
    public class Seasons
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IList<Episodes> { get; set; }
    }
    
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IList<Seasons> { get; set; }
    }
