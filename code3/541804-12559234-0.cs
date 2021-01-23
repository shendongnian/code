     public class SizeHelper
        {
            
    
            private static int GetTypeSizeArray(string typeName, object objValue)
            {
                switch (typeName)
                {
                    case "System.Double[]":
                        return sizeof(System.Double) * ((System.Double[]) objValue).Length ;
                    case "System.Single[]":
                        return sizeof(System.Single) * ((System.Single[])objValue).Length;
                    case "System.Char[]":
                        return sizeof(System.Char) * ((System.Char[])objValue).Length;
                    case "System.Int16[]":
                        return sizeof(System.Int16) * ((System.Int16[])objValue).Length;
                    case "System.Int32[]":
                        return sizeof(System.Int32) * ((System.Int32[])objValue).Length;
                    case "System.Int64[]":
                        return sizeof(System.Int64) * ((System.Int64[])objValue).Length;
                    case "System.UInt16[]":
                        return sizeof(System.UInt16) * ((System.UInt16[])objValue).Length;
                    case "System.UInt32[]":
                        return sizeof(System.UInt32) * ((System.UInt32[])objValue).Length;
                    case "System.UInt64[]":
                        return sizeof(System.UInt64) * ((System.UInt64[])objValue).Length;
                    case "System.Decimal[]":
                        return sizeof(System.Decimal) * ((System.Decimal[])objValue).Length;
                    case "System.Byte[]":
                        return sizeof(System.Byte) * ((System.Byte[])objValue).Length;
                    case "System.SByte[]":
                        return sizeof(System.SByte) * ((System.SByte[])objValue).Length;
                    case "System.Boolean":
                        return sizeof (System.Boolean)*((System.Boolean[]) objValue).Length;
                    default:
                        return 0;
                }
    
            }
    
            public static int GetSize(object obj)
            {
                Type t = obj.GetType();
    
                FieldInfo[] fields = t.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                int size = 0;
                foreach (FieldInfo fieldInfo in fields)
                {
                    if (fieldInfo.FieldType.BaseType.FullName.Equals("System.ValueType"))
                    {
                        size += GetTypeSize(fieldInfo.FieldType.FullName);
                    }
                    else if (fieldInfo.FieldType.BaseType.FullName.Equals("System.Array"))
                    {
                        var subObj = fieldInfo.GetValue(obj);
                        if (subObj != null)
                            size += GetTypeSizeArray(fieldInfo.FieldType.FullName, subObj);
                    }
                    else if(fieldInfo.FieldType.FullName.Equals("System.String"))
                    {
                        var subObj = fieldInfo.GetValue(obj);
                        if (subObj != null)
                        {
                            size += subObj.ToString().Length*sizeof (System.Char);
                        }
                    }
                    else
                    {
                        var subObj = fieldInfo.GetValue(obj);
                        if (subObj != null)
                            size += GetSize(subObj);
                    }
                }
                return size;
            }
    
            private static int GetTypeSize(string typeName)
            {
                switch (typeName)
                {
                    case "System.Double":
                        return sizeof(System.Double);
                    case "System.Single":
                        return sizeof(System.Single);
                    case "System.Char":
                        return sizeof(System.Char);
                    case "System.Int16":
                        return sizeof(System.Int16);
                    case "System.Int32":
                        return sizeof(System.Int32);
                    case "System.Int64":
                        return sizeof(System.Int64);
                    case "System.UInt16":
                        return sizeof(System.UInt16);
                    case "System.UInt32":
                        return sizeof(System.UInt32);
                    case "System.UInt64":
                        return sizeof(System.UInt64);
                    case "System.Decimal":
                        return sizeof(System.Decimal);
                    case "System.Byte":
                        return sizeof(System.Byte);
                    case "System.SByte":
                        return sizeof(System.SByte);
                     case "System.Boolean":
                        return sizeof (System.Boolean);
                    default:
                        return 0;
                }
            }
        }
