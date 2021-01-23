        private SqlDbType GetDBType(System.Type type)
        {
            SqlParameter param;
            System.ComponentModel.TypeConverter tc;
            param = new SqlParameter();
            tc = System.ComponentModel.TypeDescriptor.GetConverter(param.DbType);
            if (tc.CanConvertFrom(type))
            {
                param.DbType = (DbType)tc.ConvertFrom(type.Name);
            }
            else
            {
                switch (type.Name)
                {
                    case "Char":
                        param.SqlDbType = SqlDbType.Char;
                        break;
                    case "SByte":
                        param.SqlDbType = SqlDbType.SmallInt;
                        break;
                    case "UInt16":
                        param.SqlDbType = SqlDbType.SmallInt;
                        break;
                    case "UInt32":
                        param.SqlDbType = SqlDbType.Int;
                        break;
                    case "UInt64":
                        param.SqlDbType = SqlDbType.Decimal;
                        break;
                    case "Byte[]":
                        param.SqlDbType = SqlDbType.Binary;
                        break;
                    default:
                        try
                        {
                            param.DbType = (DbType)tc.ConvertFrom(type.Name);
                        }
                        catch
                        {
                            // Some error handling
                        }
                        break;
                }
            }
            return param.SqlDbType;
        }
