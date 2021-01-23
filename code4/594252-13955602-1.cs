    public static class SerializerExtension
    {
        public static String OneWaySerialize(this Object obj)
        {
            if (Object.ReferenceEquals(obj, null))
            {
                return "NULL";
            }
            if (obj.GetType().IsPrimitive || obj.GetType() == typeof(String))
            {
                if (obj is String)
                    return String.Format("\"{0}\"", obj);
                if (obj is Char)
                    return String.Format("'{0}'", obj);
                return obj.ToString();
            }
            StringBuilder builder = new StringBuilder();
            Type objType = obj.GetType();
            if (IsEnumerableType(objType))
            {
                builder.Append("[");
                IEnumerator enumerator = ((IEnumerable)obj).GetEnumerator();
                Boolean moreElements = enumerator.MoveNext();
                while (moreElements)
                {
                    builder.Append(enumerator.Current.OneWaySerialize());
                    moreElements = enumerator.MoveNext();
                    if (moreElements)
                    {
                        builder.Append(",");
                    }
                }
                builder.Append("]");
            }
            else
            {
                builder.AppendFormat("{0} {{", objType.Name);
                PropertyInfo[] properties = objType.GetProperties();
                for (Int32 p = properties.Length; p > 0; p--)
                {
                    PropertyInfo prop = properties[p-1];
                    String propName = prop.Name;
                    Object propValue = prop.GetValue(obj, null);
                    builder.AppendFormat("{0}={1}", propName, propValue.OneWaySerialize());
                    if (p > 1)
                    {
                        builder.Append(",");
                    }
                }
                builder.Append("}");
            }
            return builder.ToString();
        }
        private static Boolean IsEnumerableType(Type type)
        {
            foreach (Type intType in type.GetInterfaces())
            {
                if (intType.IsGenericType && intType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                {
                    return true;
                }
            }
            return false;
        }
    }
    someDefinedObject.OneWaySerialize();
