    public string Foo(string param1)
    {
        if (param1 == null)
        {
            throw new ArgumentNullException(nameof(param1));
        }
        return Foo(param1, "param2 default", "param3 default");
    }
