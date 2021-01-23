    public static PropertyInfo GetPropertyByDataMemberName(string dataMemberName)
    {
        var st = new StackTrace();
        var type = ((System.Reflection.MemberInfo)(st.GetFrame(0).GetMethod())).ReflectedType;
        return type // argh! can't call this statically!
            .GetProperties()
            .Where(z => Attribute.IsDefined(z, typeof(DataMemberAttribute)))
            .Single(z => ((DataMemberAttribute)Attribute
                .GetCustomAttribute(z, typeof(DataMemberAttribute))).Name == dataMemberName);
    }
