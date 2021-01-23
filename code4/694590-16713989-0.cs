    static void Extension<T>(this string s, T t) {}
    static void Main()
    {
        string s = "";
        int i = 123;
        s.Extension(i); // fine
        s.Extension((dynamic)i); // doesn't compile; 
    }
