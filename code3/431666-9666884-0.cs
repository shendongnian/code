    public class UserDetails
    {
        private static UserDetails _instance;
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        private UserDetails() {}
        public static UserDetails Instance
        {
            get
            {
                if (_instance == null)
                {
                     _instance = new UserDetails();
                }
                return _instance;
            }
        }
    }
