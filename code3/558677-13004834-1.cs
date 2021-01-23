    public static void CallUserFuncArray(string[] func, params string[] args)
    {
        var type = Type.GetType(func[0]);
        if (type == null)
        {
            throw new ArgumentException("The specified Class could not be found");
        }
        var method = type.GetMethod(func[1], BindingFlags.Static | BindingFlags.Public);
        if (method== null)
        {
            throw new ArgumentException("The specified Method could not be found");
        }
        method.Invoke(null, args);
    }
