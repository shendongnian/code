    public static void Touch(MyObject obj, string otherParameter)
    {
        obj.Value = otherParameter;
        foreach (var child in obj.Object)
        {
            Touch(child, otherParameter);
        }
    }
