    public interface IIdentity
    {
        int ID { get; }
    }
    public class Customer : IIdentity
    {
        public int ID { get; set;}
        public string FirstName;
        public string LastName;
    }
    public class Item : IIdentity
    {
        public int ID { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
