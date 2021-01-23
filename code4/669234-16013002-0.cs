    [StructLayout(LayoutKind.Explicit)]
    public struct RECT
    {
        [FieldOffset(4)]  public int top;
        [FieldOffset(8)]  public int right;
        [FieldOffset(12)] public int bottom;
        [FieldOffset(0)]  public int left;
    }
