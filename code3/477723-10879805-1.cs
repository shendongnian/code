    public static ColumnNameAttribute[] Read<T>(Expression<Func<T>> func)
    {
        var member = func.Body as MemberExpression;
        if(member == null) throw new ArgumentException(
             "Lambda must resolve to a member");
        return (ColumnNameAttribute[])Attribute.GetCustomAttributes(
             member.Member, typeof(ColumnNameAttribute), false);
    }
