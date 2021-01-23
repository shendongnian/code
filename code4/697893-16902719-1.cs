    [StructLayout(LayoutKind.Sequential)]
    public struct PropertySpec
    {
        public PropertySpecKind kind;
        public PropertySpecData data;
    }
    [StructLayout(LayoutKind.Explicit)]
    public struct PropertySpecData
    {
        [FieldOffset(0)]
        public uint propertyId;
        
        [FieldOffset(0)]
        public IntPtr name;
    }
