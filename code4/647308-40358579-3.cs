    public static class EnumExtensions
    {
        public static int ToInt<T>(this T soure) where T : IConvertible//enum
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");
            return (int) (IConvertible) soure;
        }
        //ShawnFeatherly funtion (above answer) but as extention method
        public static int Count<T>(this T soure) where T : IConvertible//enum
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");
            return Enum.GetNames(typeof(T)).Length;
        }
    }
