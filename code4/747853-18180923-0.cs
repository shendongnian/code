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
        T maxValue = MaxValue((dynamic)value);
        maxValue.Dump();
    }
    
    public int MaxValue(int dummy)
    {
        return int.MaxValue;
    }
    
    public double MaxValue(double dummy)
    {
        return double.MaxValue;
    }
    
    public byte MaxValue(byte dummy)
    {
        return byte.MaxValue;
    }
    
    public object MaxValue(object dummy)
    {
        // This method will catch all types that has no specific method
        throw new NotSupportedException(dummy.GetType().Name);
    }
