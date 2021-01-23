    public static class EnumExtensionMethods
    {
        public static string GetDescription(this Enum enumValue)
        {
            object[] attr = enumValue.GetType().GetField(enumValue.ToString())
                .GetCustomAttributes(typeof (DescriptionAttribute), false);
            
            return attr.Length > 0 
               ? ((DescriptionAttribute) attr[0]).Description 
               : enumValue.ToString();            
        }
        public static T ParseEnum<T>(this string stringVal)
        {
            return (T) Enum.Parse(typeof (T), stringVal);
        }
    }
    //Usage with an ASP.NET DropDownList
    foreach(MyEnum value in Enum.GetValues<MyEnum>())
       myDDL.Items.Add(New ListItem(value.GetDescription(), value.ToString())
    ...
    var selectedEnumValue = myDDL.SelectedItem.Value.ParseEnum<MyValues>()
