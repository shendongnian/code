    public static bool IsConvertibleToSqlDbType(String type)
    {
        switch(type) {
            case "System.Int64":
            case "System.Data.SqlTypes.SqlInt64":
                return true;
            case "System.Boolean":
            case "System.Data.SqlTypes.SqlBoolean":
                return true;
            case "System.String":
            case "System.Data.SqlTypes.SqlString":
                return true;
            case "System.DateTime":
            case "System.Data.SqlTypes.SqlDateTime":
                return true;
            case "System.Decimal":
            case "System.Data.SqlTypes.SqlDecimal":
                return true;
            case "System.Double":
            case "System.Data.SqlTypes.SqlDouble":
                //SetSqlDbType (SqlDbType.Float);
                return true;
            case "System.Byte[]":
            case "System.Data.SqlTypes.SqlBinary":
                return true;
            case "System.Byte":
            case "System.Data.SqlTypes.SqlByte":
                return true;
            case "System.Int32":
            case "System.Data.SqlTypes.SqlInt32":
                return true;
            case "System.Single":
            case "System.Data.SqlTypes.Single":
                return true;
            case "System.Int16":
            case "System.Data.SqlTypes.SqlInt16":
                return true;
            case "System.Guid":
            case "System.Data.SqlTypes.SqlGuid":
                return true;
            case "System.Money":
            case "System.SmallMoney":
            case "System.Data.SqlTypes.SqlMoney":
                return true;
            case "System.Object":
                return true;
            default:
                return false;
        }
    }
			
                    
