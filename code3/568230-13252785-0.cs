       public static T ConvertToEnum<T>(this string value)
        {
            if (typeof(T).BaseType != typeof(Enum))
            {
                throw new InvalidCastException("The specified object is not an enum.");
            }
            if (Enum.IsDefined(typeof(T), value.ToUpper()) == false)
            {
                throw new InvalidCastException("The parameter value doesn't exist in the specified enum.");
            }
            return (T)Enum.Parse(typeof(T), value.ToUpper());
        }
