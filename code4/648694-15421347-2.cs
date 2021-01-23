    public override int GetHashCode()
    {
        int hash = 23;
        unchecked
        {
            hash *= 17 + A.GetHashCode();
            hash *= 17 + B.GetHashCode();
            hash *= 17 + C.GetHashCode();
            // ...#
            if(L != null)
            {
                hash *= 17 + L.Length;
                foreach(var d in L)
                    hash *= 17 + d.GetHashCode();
            }
            if (M != null)
            {
                hash *= 17 + M.Length;
                foreach (var d in M)
                    hash *= 17 + d.GetHashCode();
            }         
        }
        return hash;
    }
