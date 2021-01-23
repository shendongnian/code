    public class Address
    {
        public int Id { get; set; }
        public virtual string StreetAddress1 { get; set; }
        public virtual string StreetAddress2 { get; set; }
        public virtual string City { get; set; }
        public virtual USState State { get; set; }
        public virtual string ZipCode { get; set; }
    }
    
    public class USState
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Text { get; set; }
    }
