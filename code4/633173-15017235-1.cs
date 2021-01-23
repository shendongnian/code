    public static class EnumHelpers
    {
        public static bool TryParse<TEnum>(string value, out TEnum result)
            where TEnum : struct
        {
            try
            {
                result = (TEnum)Enum.Parse(typeof(TEnum), value); 
            }
            catch
            {
                result = default;
                return false;
            }
            return true;
        }
    }
