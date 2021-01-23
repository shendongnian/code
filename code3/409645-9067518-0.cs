    enum e
    {
        [Description("10:30 a.m.")]
        AM1030,    
        [Description("10:31 a.m.")]
        AM1031,
        [Description("10:32 a.m.")]
        AM1032,
    }
        var type = e.GetType();
        var memInfo = type.GetMember(e.AM1030.ToString());
        var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
        var description = ((DescriptionAttribute)attributes[0]).Description;
