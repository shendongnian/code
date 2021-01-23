    public static bool operator ==(Foo x, Foo y)
    {
        return MyEquality(x, y);
    }
    public static bool operator !=(Foo x, Foo y)
    {
        return !MyEquality(x, y);
    }
