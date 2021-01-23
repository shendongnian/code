    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public unsafe struct Node
    {
        [FieldOffset(0)]
        public int LinkCount;
        [FieldOffset(4)]
        private fixed byte _linksData[10 * sizeof(Link)];
        public Link* Links { get { return _linksData; } };
    }
