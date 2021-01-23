    static void Main(string[] args)
    {
        int? i = 5;
        object x = new object();
        object o = FetchValue("x", i);
        o = FetchValue("x", x);
    }
    private static T? FetchValue<T>(string name, T? p) where T : struct
    {
        T? result = (T?)FetchValue(name, (object)p);
        return result;
    }
    private static T FetchValue<T>(string name,
        T default_value = default (T)) // default(T) where T is a reference type will always be null!
        where T : class
    {
        // do whatever you want
        var page = HttpContext.Current.Handler as Page;
        string str = page.Request.QueryString[name];
        if (str == null)
        {
            if (default_value == null)
            {
                throw new HttpRequestValidationException("A " + name + " must be specified.");
            }
            else
            {
                return default_value;
            }
        }
        return (T)Convert.ChangeType(str, typeof(T));
    }
