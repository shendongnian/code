    public class InvoiceComparer : IEqualityComparer<Invoice>
    {
        public bool Equals(Invoice x, Invoice y)
        {
            if (x == null || y == null) return false;
            return x.InvoiceNo == y.InvoiceNo;
        }
        public int GetHashCode(Invoice obj)
        {
            if (obj == null) return int.MinValue;
            return obj.InvoiceNo.GetHashCode();
        }
    }
