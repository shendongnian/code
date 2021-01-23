    public class Result
    {
        public Data[] data { get; set; }
    }
    
    public class Data
    {
        public CurrentLocation current_location { get; set; }
        public WorkHistory[] work_history { get; set; }
        public EducationHistory[] education_history { get; set; }
    }
    
    public class EducationHistory
    {
        public string name { get; set; }
        public int? year { get; set; }
        public string school_type { get; set; }
    }
    
    public class WorkHistory
    {
        public string company_name { get; set; }
        public Location location { get; set; }
    }
    
    public class CurrentLocation
    {
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
    }
    
    public class Location
    {
        public string city { get; set; }
        public string state { get; set; }
    }
