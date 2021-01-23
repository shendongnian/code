    public override int GetHashCode()
    {
        int hash = 19;
        hash = hash * 31 + (ID == null ? 0 : ID.GetHashCode());
        hash = hash * 31 + (Name == null ? 0 : Name.GetHashCode());
        return hash;
    }
