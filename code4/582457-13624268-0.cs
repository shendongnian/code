    public class EndDate
    {
        public int year { get; set; }
    }
    
    public class StartDate
    {
        public int year { get; set; }
    }
    
    public class Value
    {
        public string degree { get; set; }
        public EndDate endDate { get; set; }
        public string fieldOfStudy { get; set; }
        public int id { get; set; }
        public string schoolName { get; set; }
        public StartDate __invalid_name__
    startDate { get; set; }
    }
    
    public class Educations
    {
        public int _total { get; set; }
        public List<Value> values { get; set; }
    }
    
    public class RootObject
    {
        public string _key { get; set; }
        public Educations educations { get; set; }
        public string emailAddress { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
