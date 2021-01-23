    public class Customer
    {
        public int Id { set; get; }
        public string FirstName { set; get; } 
        public string LastName { set; get; } 
        [NotMapped]
        public int FullName { set; get; }
    }
