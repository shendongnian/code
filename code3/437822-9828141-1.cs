    override GetHashCode(object obj)
    {
     unchecked
        {
            int hash = 17;
            
            hash = hash * 23 + id.GetHashCode();
            hash = hash * 23 + name.GetHashCode();
            return hash;
        }
    }
