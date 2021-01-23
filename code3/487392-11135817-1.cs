    [Flags]
    public enum MyEnum {
        Value1 = 1,
        Value2 = 2,
        Value3 = 4,
        Value4 = 8,
        Value5 = 16,
        Value6 = 32,
    }
    public void Foo(MyEnum value){
        if (value & MyEnum.Value1 > 0){
            // we have Value1 passed
        }
    }
