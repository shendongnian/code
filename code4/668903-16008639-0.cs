    public enum MyColors{
    [Description("Editor Color")]
    White,
    [Description("Errors Color")]
    Red,
    [Description("Comments Color")]
    Green
    }
    var type = typeof(MyColors);
    var memInfo = type.GetMember(MyColors.White.ToString());
    var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute),
    false);
    var description = ((DescriptionAttribute)attributes[0]).Description;
