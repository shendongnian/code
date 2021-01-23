    public class Token
    {
        public int ID { get; set; }
        public string Location { get; set; }
    
        public virtual List<User> Contact { get; set; }
    }
    
    public class User
    {
        public int ID { get; set; }
        public int TokenID { get; set; }
        public string Name { get; set; }
    
        public virtual Token Token { get; set; }
    }
