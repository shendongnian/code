    public class Customer
    {
        public Int32 Id { get; set; }
        public Int32 CustomerLevel { get; set; }
        /* other properties */
        public Customer()
        {
            this.CustomerLevel = 1;
        }
    }
