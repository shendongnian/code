    [StructLayout(LayoutKind.Explicit)]
    public struct PropertySpec
    {
        [FieldOffset(0)]
        public PropertySpecKind kind;
        [FieldOffset(4)]
        public uint propertyId;
        [FieldOffset(4)]
        public IntPtr name;
    }
