    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();
            t.OverrideReadonly("TestField", 5);
            t.OverrideReadonly("TestField2", 6);
            t.OverrideReadonly("TestField3", new Test());
        }
    }
    class Test
    {
        protected readonly Int32 TestField = 1;
        protected readonly Int32 TestField2 = 2;
        protected readonly Test TestField3 = null;
        public void OverrideReadonly(String fieldName, Object value)
        {
            FieldInfo field = typeof(Test).GetField(fieldName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            field.SetValue(this, value);
        }
    }
