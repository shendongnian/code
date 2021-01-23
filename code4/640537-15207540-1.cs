    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        protected CustomerType CustomerType { get; set; }
        [NotMapped]
        public string Type 
        { 
            get { return CustomerType.Type; }
            set { CustomerType.Type = value; }
        }
    }
