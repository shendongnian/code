    Dictionary<string, Type> dict = new Dictionary<string, Type>();
    public void Method<T>(string text)
    {
        dict.Add(text, typeof(T));
    }
    public void Usage()
    {
        Method<string>("string");
        Method<IList>("list");
        Method<Action>("action");
    }
