    public override int GetHashCode()
    {
        int hash = 23;
        hash = hash * 31 + Equipment.GetHashCode();
        hash = hash * 31 + Destiny.GetHashCode();
        return hash;
    }
