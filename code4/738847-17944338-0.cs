    public sealed class MyComplexObjEnum : Enumeration<ComplexObj>
    {
        public MyComplexObjEnum(ComplexObj enumVal) : base( enumVal) { }
        public static readonly MyComplexObjEnum EnumVal1 = new MyComplexObjEnum(new ComplexObj("val1", 455, null));
        public static readonly MyComplexObjEnum EnumVal2 = new MyComplexObjEnum(new ComplexObj("val2", 456, null));
        public static readonly MyComplexObjEnum EnumVal3 = new MyComplexObjEnum(new ComplexObj("val3", 457, null));
    }
    public class ComplexObj 
    {
        private readonly string _a;
        private readonly int _b;
        private readonly string _c;
        public ComplexObj(string a, int b, string c)
        {
            _a = a;
            _b = b;
            _c = c;
        }
    }
