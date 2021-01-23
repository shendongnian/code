    switch(Type.GetTypeCode(obj.GetType()) {
       case TypeCode.String:
       case TypeCode.Int32:
       case TypeCode.Double:
       case TypeCode.Decimal:
          // do stuff for "special" types, for some value of "special"
          ...
          break;
       default:
          // do stuff for all other types
          ...
          break;
    }
