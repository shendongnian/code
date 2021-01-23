    enum TestEnum {
        [Description("My first value")]
        Value1,
        Value2,
        [Description("Last one")]
        Value99
    }
    
    var items = default(TestEnum).ToEnumDescriptionsList();
	// or: TestEnum.Value1.ToEnumDescriptionsList();
	// Alternative: EnumExtensions.ToEnumDescriptionsList<TestEnum>()
	foreach (var item in items) {
    	Console.WriteLine("{0} - {1}", item.Key, item.Value);
    }
    Console.ReadLine();
