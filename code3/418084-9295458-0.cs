    public static class Base36Code39Converter
    {
        private static BaseConverter _conv = 
            new BaseConverter(36, new[]{ '0', '1', ... 'Z' });
        public static int ToInt(string val)
        {
            return _conv.ToInt(val);
        }
    }
