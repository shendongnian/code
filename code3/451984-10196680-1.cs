    public class MyClass
    {
        public static explicit operator MyClass(SomeOtherType other)
        {
            return new MyClass { /* TODO: provide a conversion here*/ };
        }
        public static explicit operator SomeOtherType(MyClass x)
        {
            return new SomeOtherType {  /* TODO: provide a conversion here*/ };
        }
    }
