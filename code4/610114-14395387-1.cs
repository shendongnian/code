    public enum MyEnum
    {
    	EnumValue1,
    	EnumValue2,
    	EnumValue3
    }
    
    private IDictionary<MyEnum, Action> Mapping = new Dictionary<MyEnum, Action>
    	{
    		{ MyEnum.EnumValue1, () => { /* Action 1 */ } },
    		{ MyEnum.EnumValue2, () => { /* Action 2 */ } },
    		{ MyEnum.EnumValue3, () => { /* Action 3 */ } }
    	};
    
    public void HandleEnumValue(MyEnum enumValue)
    {
    	if (Mapping.ContainsKey(enumValue))
    	{
    		Mapping[enumValue]();
    	}
    }
