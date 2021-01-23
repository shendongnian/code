    using System.Data.Spatial;
    
    public class University  
    { 
        public int UniversityID { get; set; } 
        public string Name { get; set; } 
        public DbGeography Location { get; set; } 
    }
