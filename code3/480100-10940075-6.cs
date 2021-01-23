    public sealed class MyFakeEnum
    {
        public static readonly MyFakeEnum Value1 = new MyFakeEnum("Value1");
        public static readonly MyFakeEnum Value2 = new MyFakeEnum("Value2");
    
        private MyFakeEnum(string name)
        {
            _name = name;
        }
    
        public static implicit operator int(MyFakeEnum value)
        {
            return GetActualValue(value._name);
        }
    
        private string _name;
    }
