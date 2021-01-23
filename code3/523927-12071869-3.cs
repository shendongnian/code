    MyType type;
    if (Enum.TryParse(abc, out type))
    {
        // can be parsed
        switch (type)
       {
           case MyType.Boolean: break;
           case MyType.Int: break;
           case MyType.Double: break;
           case MyType.String: break;
       }
    }
