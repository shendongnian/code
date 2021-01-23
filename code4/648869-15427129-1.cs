    switch(Type.GetTypeCode(obj.GetType()) {
        case TypeCode.Boolean:
        case TypeCode.Byte:
        case TypeCode.SByte:
        case TypeCode.Char:
        case TypeCode.Decimal:
        case TypeCode.Double:
        case TypeCode.Single:
        case TypeCode.Int32:
        case TypeCode.UInt32:
        case TypeCode.Int64:
        case TypeCode.UInt64:
        case TypeCode.Int16:
        case TypeCode.UInt16:
        case TypeCode.String:
          // do stuff for "built in" types
          ...
          break;
       default:
          // do stuff for all other types
          ...
          break;
    }
