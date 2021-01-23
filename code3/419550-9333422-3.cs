    public class Tag
    {
        [Key]
        public int ID { get; set; }
    }
    
    public abstract class User 
    {
        [Key]
        public int ID { get; set; }
        public string Forename { get; set; }        
        public string Surename { get; set; }
    }
    
    public class Lecturer : User
    {
        public IEnumerable<Tag> Forename { get; set; }
    }
    
    
    public class Student : User
    {
        public IEnumerable<Tag> Forename { get; set; }
    }
    
    public class Project
    {
        [Key]
        public int ID { get; set; }
        
        public User Proposer { get; set; }
    }
