    public static class EnumHelper
    {
        public static TEnum[] GetValues<TEnum>()
        {
            return typeof(TEnum)
                .GetFields(BindingFlags.Static | BindingFlags.Public)
                .Select(fieldInfo => (TEnum)fieldInfo.GetValue(null))
                .ToArray();
        }
    }
