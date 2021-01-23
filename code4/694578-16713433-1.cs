    public static string EnumToJsObj(Enum enumType)
    {
        Type t = enumType.GetType();
        return new JavaScriptSerializer().Serialize(
                Enum.GetNames(t).ToDictionary(e => e, e => (int)Enum.Parse(t,e))
        );
    }
