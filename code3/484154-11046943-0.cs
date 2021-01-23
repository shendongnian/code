    public int CompareTo(Circle c)
    {
        return c == null ? 1 : CompareAreas(this.Area(), c.Area());
    }
    public int CompareAreas(double a, double b)
    {
        return a > b ? 1 : a == b ? 0 : -1;
    }
