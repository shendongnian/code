    enum MyEnum
    {
        Undefined,
        Set,
        Reset
    }
    class MyEnumAttribute : Attribute
    {
        public MyEnumAttribute(MyEnum value)
        {
            Value = value;
        }
        public MyEnum Value { get; private set; }
    }
    [MyEnum(MyEnum.Reset)]
    class ResetClass
    {
    }
    [MyEnum(MyEnum.Set)]
    class SetClass
    {
    }
    [MyEnum(MyEnum.Undefined)]
    class UndefinedClass
    {
    }
