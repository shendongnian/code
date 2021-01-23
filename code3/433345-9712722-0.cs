    /* ... code .... */
    System.Type type = rdr.GetFieldType(c);
    switch (Type.GetTypeCode(type))
    {
        case TypeCode.DateTime:
            break;
        case TypeCode.String:
            break;
        default: break;
    }
    /* ... code .... */
