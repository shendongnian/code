    public static class MyConvertingClass
    {
        public static T Convert<T>(APIElement element)
        {
            System.Type type = typeof(T);
            if (conversions.ContainsKey(type))
                return (T)conversions[type](element);
            else
                throw new FormatException();
        }
    
        private static readonly Dictionary<System.Type, Func<Element, object>> conversions = new Dictionary<Type,Func<Element,object>>
        {
            { typeof(bool), n => n.GetValueAsBool() },
            { typeof(char), n => n.GetValueAsChar() },
            { typeof(DateTime), n => n.GetValueAsDatetime() },
            { typeof(float), n => n.GetValueAsFloat32() },
            { typeof(double), n => n.GetValueAsFloat64() },
            { typeof(int), n => n.GetValueAsInt32() },
            { typeof(long), n => n.GetValueAsInt64() },
            { typeof(string), n => n.GetValueAsString() }
        };
    }
