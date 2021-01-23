    public static int StringToInt(this Numbers number,
     Expression<Func<Numbers, string>> prop)
    {
        try
        {
            return Convert.ToInt32(prop.Compile()(number));
        }
        catch (Exception ex)
        {
            var expression = (MemberExpression)prop.Body;
            string name = expression.Member.Name;
            throw new MissingMemberException(string.Format("Invalid member {0}", name));
        }
    }
