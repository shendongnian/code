    public class CustomerWithOrdersModel
    {
        public CustomerWithOrdersModel(Customer customer)
        {
            Id = customer.Id;
            FullName = string.Format("{0}, {1}", customer.LastName, customer.FirstName);
            Orders = customer.Orders.ToList();
        }
    
        public int Id { get; set; }
    
        public string FullName { get; set; }
    
        public IEnumerable<Order> Orders { get; set; }
    }
