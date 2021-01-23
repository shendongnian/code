    public class ClassComplex<T> 
    {
        public T MyGenericValue { get; set; }
        public string MyStringValue { get; set; }
        public int MyIntValue { get; set; }
        public static implicit operator ClassComplex(ClassComplex<T> a)
        {
            return new ClassComplex() { MyIntValue = a.MyIntValue , MyStringValue = a.MyStringValue };
        }
    }
    public class ClassComplex
    {
        public string MyStringValue { get; set; }
        public int MyIntValue { get; set; }
    }
    public class Test
    {
        public Test()
        {
            ClassComplex<int> ccg = new ClassComplex<int>();
            ccg.MyGenericValue = 1;
            ccg.MyIntValue = 2;
            ccg.MyStringValue = "3";
            ClassComplex cc = ccg;
        }
    }
