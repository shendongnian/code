    public static class EnumHelper
    {
        public static string[] GetNames<T>() where T : struct
        {
            return Enum.GetNames(typeof(T))
        }
    }
