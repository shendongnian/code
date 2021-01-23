    public static string EnumToJsObj(Enum enumType)
    {
        Type t = enumType.GetType();
        return new JavaScriptSerializer().Serialize(
                Enum.GetNames(t).Zip(Enum.GetValues(t).Cast<int>(), (n, v) => new { n, v })
                                .ToDictionary(kv=>kv.n,kv=>kv.v)
        );
    }
