    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public struct DATASTRUCT
    {
        public byte Rel;
        public long Time;
        public byte Validated;
        public IntPtr Data; //pointer to unmanaged string.
    }
    int szStruct = Marshal.SizeOf(typeof(DATASTRUCT));
    DATASTRUCT[] localStructs = new DATASTRUCT[nAllocs];
    for(uint i = 0; i < nallocs; i++)
        localStructs[i] = (DATASTRUCT)Marshal.PtrToStructure(new IntPtr(pAllocs.ToInt32() + (szStruct * i)), typeof(DATASTRUCT));
