    public enum url
    {
       [Description(@"/_layouts/Admin/test1.aspx")] Test1,
       [Description(@"/_layouts/Admin/test2.aspx")] Test2,
       [Description(@"/_layouts/Admin/test2.aspx")] Test3
    }
    ...
 
    public static string GetDescription(this Enum enumValue)
    {
        object[] attr = enumValue.GetType().GetField(enumValue.ToString())
                .GetCustomAttributes(typeof (DescriptionAttribute), false);
            if (attr.Length > 0)
                return ((DescriptionAttribute) attr[0]).Description;
            return enumValue.ToString();
    }
    //usage
    Response.Redirect(url.Test1.GetDescription());
