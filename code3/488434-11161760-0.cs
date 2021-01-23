    private static Dictionary<string, Func<CommonBaseClass>> DataTypes =
        new Dictionary<string, Func<CommonBaseClass>>
        {
            { "type1", () => new Type1Object() }
            { "type2", () => new Type2Object() },
            { "type3", () => new Type3Object() }
        };
    public static CommonBaseClass GetGenericObject(string type)
    {
        return DataTypes[type]();
    }
