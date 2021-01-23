    public IEnumerable<string> getEnumValues<T>() where  T: struct,IConvertible
                {
                var type = typeof(T);
                if (type.IsEnum)
                    {
                    return Enum.GetNames(type);
                    }
                else
                    {
                    throw new ArgumentException("Type parameter specified is not an enum type.");
                    }
                }
