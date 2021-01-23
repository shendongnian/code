        int i;
        switch (Type.GetTypeCode(reader.GetFieldType(0)))
        {
            case TypeCode.Int16: i = reader.GetInt16(0); break;
            case TypeCode.Int32: i = reader.GetInt32(0); break;
            // TODO: any other cases you need to handle
            default: throw new NotSupportedException();
        }
