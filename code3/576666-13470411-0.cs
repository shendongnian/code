    public class Service
    {
        public int idservice { get; set; }
    
        public string title { get; set; }
    
        public string message { get; set; }
    }
    
    public class UserServices
    {
        public int id_user { get; set; }
    
        public List<Service> services { get; set; }
    }
