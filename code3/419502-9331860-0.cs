    [StructLayout(LayoutKind.Explicit)]
    unsafe struct Fruit
    {
        [FieldOffset(0)] public fixed char name[20];
        [FieldOffset(20)] public bool IsRound;
        [FieldOffset(21)] public float Diameter;
        [FieldOffset(21)] public float Length;
        [FieldOffset(25)] public float Width;
    }
