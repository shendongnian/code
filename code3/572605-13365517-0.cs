        public static T ToEnumValue<T, E>(this E enumType)
        {
            return (T)Enum.ToObject(typeof(E), enumType);
        }
        public static E ToEnumType<T, E>(this T enumString)
        {
            return (E)Enum.Parse(typeof(E), enumString.ToString());
        }
