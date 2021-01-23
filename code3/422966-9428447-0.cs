    string s = "2012-02-23 10:00:00";
    Type t = Type.GetType("System.Nullable`1[[System.DateTime, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]");
    object d;
    if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
    {
        if (String.IsNullOrEmpty(s))
            d = null;
        else
            d = Convert.ChangeType(s, t.GetGenericArguments()[0]);
    }
    else
    {
        d = Convert.ChangeType(s, t);
    }
