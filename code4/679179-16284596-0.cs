    public int Find(List<Coffee> c, Coffee x) {
        return c.IndexOf(x);
    }
    public override int GetHashCode()
    {
        return Name == null ? 0 : Name.GetHashCode();
    }
