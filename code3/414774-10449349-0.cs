    public static class EnumExtender
    {
        /// <summary>
        /// Adds a flag value to enum.
        /// Please note that enums are value types so you need to handle the RETURNED value from this method.
        /// Example: myEnumVariable = myEnumVariable.AddFlag(CustomEnumType.Value1);
        /// </summary>
        public static T AddFlag<T>(this Enum type, T enumFlag)
        {
            try
            {
                return (T)(object)((int)(object)type|(int)(object)enumFlag);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(string.Format("Could not append flag value {0} to enum {1}",enumFlag, typeof(T).Name), ex);
            }
        }
        /// <summary>
        /// Removes the flag value from enum.
        /// Please note that enums are value types so you need to handle the RETURNED value from this method.
        /// Example: myEnumVariable = myEnumVariable.RemoveFlag(CustomEnumType.Value1);
        /// </summary>
        public static T RemoveFlag<T>(this Enum type, T enumFlag)
        {
            try
            {
                return (T)(object)((int)(object)type & ~(int)(object)enumFlag);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(string.Format("Could not remove flag value {0} from enum {1}", enumFlag, typeof(T).Name), ex);
            }
        }
        /// <summary>
        /// Sets flag state on enum.
        /// Please note that enums are value types so you need to handle the RETURNED value from this method.
        /// Example: myEnumVariable = myEnumVariable.SetFlag(CustomEnumType.Value1, true);
        /// </summary>
        public static T SetFlag<T>(this Enum type, T enumFlag, bool value)
        {
            return value ? type.AddFlag(enumFlag) : type.RemoveFlag(enumFlag);
        }
        /// <summary>
        /// Checks if the flag value is identical to the provided enum.
        /// </summary>
        public static bool IsIdenticalFlag<T>(this Enum type, T enumFlag)
        {
            try
            {
                return (int)(object)type == (int)(object)enumFlag;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Convert provided enum type to list of values.
        /// This is convenient when you need to iterate enum values.
        /// </summary>
        public static List<T> ToList<T>()
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException();
            var values = Enum.GetNames(typeof(T));
            return values.Select(value => value.ToEnum<T>()).ToList();
        }
        /// <summary>
        /// Present the enum values as a comma separated string.
        /// </summary>
        public static string GetValues<T>()
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException();
            var values = Enum.GetNames(typeof(T));
            return string.Join(", ", values);
        }
    }
