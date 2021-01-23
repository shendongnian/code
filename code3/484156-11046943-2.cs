    public static bool operator >(Circle a, Circle b)
    {
        return Compare(a, b) > 0;
    }
    public static bool operator <(Circle a, Circle b)
    {
        return Compare(a, b) < 0;
    }
    public static int Compare(Circle a, Circle b)
    {
        return a == null && b == null ? 0 : a == null ? 1 : a.CompareTo(b);
    }
