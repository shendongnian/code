        public static int? GetValue<T>(string text)
        {
            var enumType = typeof (T);
            if (!enumType.IsEnum)
                return null;
            int? val;
            try
            {
                val = (int) Enum.Parse(enumType, text);
            }
            catch (Exception)
            {
                val = null;
            }
            return val;
        }
