    public static List<KeyValuePair<TEnum, string>> ToEnumDescriptionsList<TEnum>(this TEnum value) {
    	return Enum
    		.GetValues(typeof(TEnum))
    		.Cast<TEnum>()
    		.Select(x => new KeyValuePair<TEnum, string>(x, ((Enum)((object)x)).GetDescription()))
    		.ToList();
    }
