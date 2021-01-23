    // 1. define a method to retrieve the enum description
    public static string ToEnumDescription(this Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());
        DescriptionAttribute[] attributes =
            (DescriptionAttribute[])fi.GetCustomAttributes(
            typeof(DescriptionAttribute),
            false);
        if (attributes != null &&
            attributes.Length > 0)
            return attributes[0].Description;
        else
            return value.ToString();
    }
    //2. this is how you would retrieve the enum based on the description:
    public static MyEnum GetMyEnumFromDescription(string description)
    {
        var enums = Enum.GetValues(typeof(MyEnum)).Cast<MyEnum>();
        
        // let's throw an exception if the description is invalid...
        return enums.First(c => c.ToEnumDescription() == description);
    }
    //3. test it:
    var enumChoice = EnumHelper.GetMyEnumFromDescription("Third");
    Console.WriteLine(enumChoice.ToEnumDescription());
