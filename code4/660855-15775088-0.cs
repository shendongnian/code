    public class Project
    {
        public int ProjectId { get; internal set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
    
        public Customer CurrentCustomer { get; set; }
        public int CurrentCustomerId { get; set; }
    }
