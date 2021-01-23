    public class CustomerGroup
    {
        public int Id { get; set; }
        public string NAme { get; set; }
        public Customer[] Customers { get; set; }
    
        public int[] CustomerIds { get { return Customers.Select(c => c.Id).ToArray(); }
    }
