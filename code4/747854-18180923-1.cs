    void Main()
    {
        Test(10);
        Test(10.234);
        Test((Byte)42);
        Test(true);
    }
    
    public void Test<T>(T value)
        where T : struct
    {
        FieldInfo maxValueField = typeof(T).GetField("MaxValue", BindingFlags.Public
            | BindingFlags.Static);
        if (maxValueField == null)
            throw new NotSupportedException(typeof(T).Name);
        T maxValue = (T)maxValueField.GetValue(null);
        maxValue.Dump();
    }
