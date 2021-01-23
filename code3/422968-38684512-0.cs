    public static T GetValue<T>(string Literal, T DefaultValue)
        {
            if (Literal == null || Literal == "" || Literal == string.Empty) return DefaultValue;
            IConvertible obj = Literal;
            Type t = typeof(T);
            Type u = Nullable.GetUnderlyingType(t);
            if (u != null)
            {
                return (obj == null) ? DefaultValue : (T)Convert.ChangeType(obj, u);
            }
            else
            {
                return (T)Convert.ChangeType(obj, t);
            }
        }
