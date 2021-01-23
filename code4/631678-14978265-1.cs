    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            // Check for null
            hash = hash * 29 + field1.GetHashCode();
            hash = hash * 29 + field2.GetHashCode();
            return hash;
        }
    }
