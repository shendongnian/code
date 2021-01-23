    public class UserViewModel 
    {
        public int Id { get; set; }
        public string ReturnUrl { get; set; }
    }
    
    public ActionResult Index(UserViewModel uvm) 
    { 
        ...
    }
