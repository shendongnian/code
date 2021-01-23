    public class Contact {
        public int ContactId { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }
    public class Phone {
        public int PhoneId { get; set; }
        public int ContactId { get; set; }
        public string PhoneNumber { get; set; }
    }
