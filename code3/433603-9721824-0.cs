    public class User
    {
        public User ()
        {
            Roles = new List<string>();
        }
        public string Name { get; set; }
        
        public List<string> Roles { get; private set; }
    }
