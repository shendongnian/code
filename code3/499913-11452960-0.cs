    public static ResourceBase Parse(string s)
    {
        if (!s.EndsWith(".js"))
            throw new Exception();
        return new JavaScript(path);
    }
