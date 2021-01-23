    IEnumerable<EnumDisplayNameAttribute> attributes = 
        Enum.GetValues(typeof(MyEnum))
            .Cast<MyEnum>()
            .Where(v => enumVar.HasFlag(v))
            .Select(v => typeof(MyEnum).GetField(v.ToString()))
            .SelectMany(f => f.GetCustomAttributes(typeof(EnumDisplayNameAttribute), false))
            .Cast<EnumDisplayNameAttribute>();
