    public static class DynamicExtension
    {
        public static dynamic ToDynamic(this T value)
        {
            return (dynamic)value;
        }
    }
