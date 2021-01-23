    public static string GetMyTable<T>(IEnumerable<T> list, params  Expression<Func<T, object>>[] fxns)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<TABLE>\n");
        sb.Append("<TR>\n");
        foreach (var fxn in fxns)
        {
            sb.Append("<TD>");
            sb.Append(GetName(fxn));
            sb.Append("</TD>");
        }
        sb.Append("</TR> <!-- HEADER -->\n");
            
        foreach (var item in list)
        {
            sb.Append("<TR>\n");
            foreach (var fxn in fxns)
            {
                sb.Append("<TD>");
                sb.Append(fxn.Compile()(item));
                sb.Append("</TD>");
            }
            sb.Append("</TR>\n");
        }
        sb.Append("</TABLE>");
        return sb.ToString();
    }
    static string GetName<T>(Expression<Func<T, object>> expr)
    {
        var member = expr.Body as MemberExpression;
        if (member != null)
            return GetName2(member);
        var unary = expr.Body as UnaryExpression;
        if (unary != null)
            return GetName2((MemberExpression)unary.Operand);
        return "?+?";
    }
    static string GetName2(MemberExpression member)
    {
        var fieldInfo = member.Member as FieldInfo;
        if (fieldInfo != null)
        {
            var d = fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            if (d != null) return d.Description;
            return fieldInfo.Name;
        }
        var propertInfo = member.Member as PropertyInfo;
        if (propertInfo != null)
        {
            var d = propertInfo.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            if (d != null) return d.Description;
            return propertInfo.Name;
        }
        return "?-?";
    }
