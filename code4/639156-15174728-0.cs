    public static class StringExtensions
    {
        public static dynamic ConvertToType(this string value)
        {
            foreach (Type type in ConvertibleTypes)
            {
                var obj = Activator.CreateInstance(type);
                var methodParameterTypes = new Type[] { typeof(string), type.MakeByRefType() };
                var method = type.GetMethod("TryParse", methodParameterTypes);
                var methodParameters = new object[] { value, obj };
                bool success = (bool)method.Invoke(null, methodParameters);
                if (success)
                {
                    return methodParameters[1];
                }
            }
            return value;
        }
        private static Type[] _convertibleTypes = null;
        private static Type[] ConvertibleTypes
        {
            get
            {
                if (_convertibleTypes == null)
                {
                    _convertibleTypes = new Type[]
                    {
                        typeof(System.SByte),
                        typeof(System.Byte), 
                        typeof(System.Int16), 
                        typeof(System.UInt16), 
                        typeof(System.Int32), 
                        typeof(System.UInt32), 
                        typeof(System.Int64), 
                        typeof(System.UInt64), 
                        typeof(System.Single), 
                        typeof(System.Double), 
                        typeof(System.Decimal),
                        typeof(System.DateTime),
                        typeof(System.Guid)
                    };
                }
                return _convertibleTypes;
            }
        }
    }
