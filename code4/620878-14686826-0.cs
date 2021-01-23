    [StructLayout(LayoutKind.Explicit)] 
    public struct LUCAM_SNAPSHOT
    {
        [FieldOffset(0)] public float exposure;
        [FieldOffset(4)] public float gain;
        [FieldOffset(8)] public float gainRed;
        [FieldOffset(8)] public float gainGrn1;
        [FieldOffset(8)] public float gainGrn2;
        [FieldOffset(12)] public float gainMag;
        [FieldOffset(12)] public float gainGrn1;
        [FieldOffset(12)] public float gainGrn2;
        [FieldOffset(12)] public float gainMag;
        [FieldOffset(16)] public byte useStrobe;
        [FieldOffset(16)] public int strobeFlags;
    }
