    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        protected CustomerType CustomerType { get; set; }
        [NotMapped]
        public string Type 
        { 
            get { return CustomerType.Type; }
            set { CustomerType.Type = value; }
        }
    }
