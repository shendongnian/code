    [StructLayout(LayoutKind.Explicit)]
    public struct Struct1
    {
        [FieldOffset(0)]
        public int Int1;
        [FieldOffset(4)]
        public int Int2;
    }
    
    [StructLayout(LayoutKind.Explicit)]
    public struct Struct2
    {
        [FieldOffset(0)]
        public long Long;
    }
    
    [StructLayout(LayoutKind.Explicit)]
    public struct Struct12Converter
    {
        [FieldOffset(0)]
        public Struct1[] S1Array;
        [FieldOffset(0)]
        public Struct2[] S2Array;
    }
    
    
    public void ConversionTest()
    {
        var int1 = 987;
        var int2 = 456;
        var int3 = 123456;
        var int4 = 789123;
    
        var s1Array = new[] 
        { 
            new Struct1 {Int1 = int1, Int2 = int2},
            new Struct1 {Int1 = int3, Int2 = int4},
        };
        
        // Write as Struct1s
        var converter = new Struct12Converter { S1Array = s1Array };
        
        // Read as Struct2s
        var s2Array = converter.S2Array;
        
        // Check: Int2 is the high part, so that must shift up
        var check0 = ((long)int2 << 32) + int1;
        Debug.Assert(check0 == s2Array[0].Long);
        // And check the second element
        var check1 = ((long)int4 << 32) + int3;
        Debug.Assert(check1 == s2Array[1].Long);
    
        // Using LinqPad Dump:
        check0.Dump();
        s2Array[0].Dump();
    
        check1.Dump();
        s2Array[1].Dump();
    
    }
    void Main()
    {
        ConversionTest();
    }
    
    
