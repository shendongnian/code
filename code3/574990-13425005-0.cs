    public static class ExtensionUtils
    {
        public static int ToZeroIfNotInt(this string valueToConvert)
        {
            int number =0;
            int.TryParse(valueToConvert,out number);
            return number;
        }
    }
