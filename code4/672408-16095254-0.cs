    struct Complex
    {
        double real;
        double imag;
    
        public override int GetHashCode()
        {
            return real.GetHashCode() ^ image.GetHashCode();
        }
    
        // ...
    }
