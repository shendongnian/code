    public class Product : IAggregateRoot
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        protected Product() { }
        public Product(string name)
        {
            Id = Guid.Empty;
            Name = name;
        }
    }
