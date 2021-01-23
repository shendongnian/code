    public class EnumWrapper<TEnum>
    {
        public static EnumWrapper<TEnum>[] GetItems()
        {
            Type type = typeof(TEnum);
            var enumObjects = Enum.GetValues(type);
            var enumTyped = enumObjects.Select((v) => (TEnum)v);
            EnumWrapper<TEnum>[] ret = enumTyped.Select((e) => new EnumWrapper<TEnum>(e));
            return ret;
        }
    }
    public string DisplayName { get; private set; }
    public TEnum  EnumValue { get; private set; }
    private EnumWrapper(TEnum enumVal)
    {
       Type type = enumVal.GetType();
       // Read attributes here. I'm leaving this out. if you need it, let me know.
       DisplayName = GetStringValueAttributeOfEnumValue(enumVal);
       EnumValue = enumVal;
    }
