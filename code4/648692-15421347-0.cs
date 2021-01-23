    public override int GetHashCode()
    {
        unchecked 
        {
            int hash = 17;
            hash = hash * 23 + A.GetHashCode();
            hash = hash * 23 + B.GetHashCode();
            hash = hash * 23 + C.GetHashCode();
            // ...
            hash = hash * 23 + L.GetHashCode();
            hash = hash * 23 + M.GetHashCode();
            return hash;
        }
    }
