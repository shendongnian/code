    class A
    {
        string a;
        int b;
        double c;
        
        public override bool Equals(object obj)
        {
            if (!(obj is A)) return obj.Equals(this); // defer to other object
            A other = (A)obj;
            return a == other.a && b == other.b && c == other.c; // check field equality
        }
        public override int GetHashCode()
        {
            int hc = 13;
            hc += a.GetHashCode() * 27;
            hc += b.GetHashCode() * 27;
            hc += c.GetHashCode() * 27;
        }
    }
