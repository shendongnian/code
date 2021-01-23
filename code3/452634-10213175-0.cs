    public class User {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Description { get; set; }
        public Location Location { get; set; }
        public String LocationPost {get{return Location.Post;}}
    }
    
