    public static class EnumHelper
    {
        public void SetFlag<TEnum>(ref TEnum enumValue, TEnum flag)
        {
             enumValue = enumValue | flag;
        }
    }
