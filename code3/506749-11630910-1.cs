        public static int TryConvertToInt32(this string value)
        {
            int result = 0;
            if (Int32.TryParse(value, out result))
                return result;
            return result;
        }
    }
