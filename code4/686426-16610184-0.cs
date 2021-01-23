    public class Customer
    {
        public virtual string Name { get; set; }
        // etc...
    }
    public class CustomerProxy
    {
        public override string Name
        {
            get
            {
                // Do additional functionality...
                return base.Name;
            }
            set
            {
                // Do additional functionality...
                base.Name = value;
            }
        }
    }
