    class Base {
        protected virtual MyEnum DefaultEnumValue { get { return 0; } }
        MyEnum enumValue;
    
        Base () {
            enumValue = DefaultEnumValue;
        }
    }
    
    class Derived : Base {
        protected override MyEnum DefaultEnumValue { get { return MyEnum.Derived; } }
    }
