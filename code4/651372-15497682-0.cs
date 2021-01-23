    public class TestClass
    {
        public virtual ValueClass Property { get; set; }
    }
    public class TestClass1 : TestClass
    {
        private ValueClass property = null;
        public override ValueClass Property
        {
            get
            {
                return (ValueClass)property;
            }
            set
            {
                property = (ValueClass)value;
            }
        }
    }
    public class TestClass2 : TestClass
    {
        private ValueClass2 property = null;
        public override ValueClass Property
        {
            get
            {
                return (ValueClass2)property;
            }
            set
            {
                property = (ValueClass2)value;
            }
        }
    }
    public class ValueClass
    {
        public int Id { get; set; }
    }
    public class ValueClass2 : ValueClass
    {
    }
