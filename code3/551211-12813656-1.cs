    public class Customer 
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
        public class Comparer : IEqualityComparer<Customer>
        {
            public bool Equals(Customer x, Customer y)
            {
                if (x == null && y == null) return true;
                if (x == null || y == null) return false;
                return x.Equals(y);
            }
            public int GetHashCode(Customer obj)
            {
                if (obj == null) return -1;
                return obj.GetHashCode();
            }
        }
    }
