    using System.Data.Spatial; //For EF5
    //using System.Data.Entity.Spatial; //For EF6
    
    public class University  
    { 
        public int UniversityID { get; set; } 
        public string Name { get; set; } 
        public DbGeography Location { get; set; } 
    }
