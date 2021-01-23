    private class MyClass
    {
        private string a;
        private string b;
        private long? c;
        private decimal d;
        private decimal e;
        private decimal f;
        public MyClass(string aa, string bb, long? cc, decimal dd, decimal ee, decimal ff)
        {
            a = aa;
            b = bb;
            c = cc;
            d = dd;
            e = ee;
            f = ff;
        }
        protected bool Equals(MyClass other)
        {
            return string.Equals(a, other.a) && string.Equals(b, other.b) && c == other.c && e == other.e && d == other.d && f == other.f;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MyClass)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (a != null ? a.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (b != null ? b.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ c.GetHashCode();
                hashCode = (hashCode * 397) ^ e.GetHashCode();
                hashCode = (hashCode * 397) ^ d.GetHashCode();
                hashCode = (hashCode * 397) ^ f.GetHashCode();
                return hashCode;
            }
        }
    }
