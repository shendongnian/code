    static public TEnum GetAllFlags<TEnum>() where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            unchecked
            {
                if (!typeof(TEnum).IsEnum)
                    throw new InvalidOperationException("Can't get flags from non Enum");
                object val = null;
                switch (Type.GetTypeCode(Enum.GetUnderlyingType(typeof(TEnum))))
                {
                    case TypeCode.Byte:
                    case TypeCode.SByte:
                        val = Enum.GetValues(typeof(TEnum))
                                    .Cast<Byte>()
                                    .Aggregate(default(Byte), ( s, f) => (byte)(s | f));
                        break;
                    case TypeCode.Int16:
                    case TypeCode.UInt16:
                        val = Enum.GetValues(typeof(TEnum))
                                    .Cast<UInt16>()
                                    .Aggregate(default(UInt16), ( s, f) => (UInt16)(s | f));
                        break;
                    case TypeCode.Int32:
                    case TypeCode.UInt32:
                        val = Enum.GetValues(typeof(TEnum))
                                    .Cast<UInt32>()
                                    .Aggregate(default(UInt32), ( s, f) => (UInt32)(s | f));
                        break;
                    case TypeCode.Int64:
                    case TypeCode.UInt64:
                        val = Enum.GetValues(typeof(TEnum))
                                    .Cast<UInt64>()
                                    .Aggregate(default(UInt64), ( s, f) => (UInt64)(s | f));
                        break;
                    default :
                        throw new InvalidOperationException("unhandled enum underlying type");
        
                }
                return (TEnum)Enum.ToObject(typeof(TEnum), val);
            }
        }
