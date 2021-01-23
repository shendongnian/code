    public static bool operator true(YourType x)
    {
        return x.IsLying ? !x.Whatever : x.Whatever;
    }
    public static bool operator false(YourType x)
    {
        return x.IsLying ? x.Whatever : !x.Whatever;
    }
