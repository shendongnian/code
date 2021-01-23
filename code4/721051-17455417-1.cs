    class A
    {
        string a;
        int b;
        double c;
        public override bool Equals(object obj)
        {
            return a == obj.a && b == obj.b && c == obj.c;
        }
        public override int GetHashCode()
        {
            unchecked { return 17 * a.GetHashCode() * b * c.GetHashCode(); }
        }
    }
