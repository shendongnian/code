    public class YourModel
    {
        string Category { get ; set ; }
    }
    
    public class YourViewModel
    {
        public List<string> PossibleCategories { get ; set ; }
        public YourModel YourData { get ; set ; }
    }
