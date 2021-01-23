    public class User
    {
        public User ()
        {
            Roles = new List<string>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        
        public List<string> Roles { get; private set; }
    }
