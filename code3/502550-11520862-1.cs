    class Product : IComparable<Product>
    {
        public string ProductName { get; set; }
        public DateTime ActivationDate { get; set; }
        public int CompareTo(Product other)
        {
            return this.ActivationDate.CompareTo(other.ActivationDate);
        }
    }
