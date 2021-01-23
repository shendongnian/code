    public class Customer
    {
        public int CustomerID { set; get; }
        public string FirstName { set; get; } 
        public string LastName{ set; get; } 
        [NotMapped]
        public int Age { set; get; }
    }
