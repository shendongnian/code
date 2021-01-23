    public class EnumTest : Attribute
    {
        public int Value;
        public object Obj;
    }
    
    public enum DemoEnum
    {
        [EnumTest(Value = (int)DemoEnum.Value1, Obj = DemoEnum.Value1)]
        Value1 = 1,
    
        [EnumTest(Value = (int)DemoEnum.Value2)]
        Value2 = 2
    }
