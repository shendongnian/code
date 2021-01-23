    public class TransactionCustomerComparer : IEqualityComparer<transaction>
    {
        public bool Equals(transaction x, transaction y)
        {
            if (x == null || y == null) return false;
            return x.customerName == y.customerName;
        }
        public int GetHashCode(transaction obj)
        {
            if (obj == null) return int.MinValue;
            return obj.customerName.GetHashCode();
        }
    } 
