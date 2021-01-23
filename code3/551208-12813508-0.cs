    public class CusComparer : EqualityComparer<Customer>
    {
        public override bool Equals(Customer x, Customer y)
        {
            return x.CustomerID == y.CustomerID;
        }
        public override int GetHashCode(Customer obj)
        {
            return obj.GetHashCode();
        }
    }
