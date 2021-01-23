    [StructLayout(LayoutKind.Sequential)]
    struct ManagedSafeArray
    {
        public ushort   dimensions;     // Count of dimensions in the SAFEARRAY
        public ushort   features;       // Flags to describe SAFEARRAY usage
        public uint     elementSize;    // Size of an array element
        public uint     locks;          // Number of times locked without unlocking
        public IntPtr   dataPtr;        // Pointer to the array data
        public uint     elementCount;   // Element count for first (only) dimension
        public int      lowerBound;     // Lower bound for first (only) dimension
    }
