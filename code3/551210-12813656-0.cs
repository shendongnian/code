    class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public override bool Equals(Object obj)
        {
            Customer cust = obj as Customer;
            if (cust == null) return false;
            return cust.CustomerID == CustomerID;
        }
        public override int GetHashCode()
        {
            return CustomerID.GetHashCode();
        }
    }
