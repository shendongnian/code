    public class Phone
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Number { get; set; }
    }
    public class User
    {
        // (etc)
        public List<Phone> Phones { get; set; }
        // (etc)        
    }
