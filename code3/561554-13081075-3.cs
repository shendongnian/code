    public struct Foo:IFoo
    {
        [System.Runtime.InteropServices.FieldOffset(0)]  public fixed byte raw[512];
        public int Raw { get{return raw;} set{raw = value;} }
    }  
