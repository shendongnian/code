    public static string Foo(this string name)
    {
       if (String.IsNullOrWhiteSpace(name))
           return "Hello world";
    
       return name;
    }
