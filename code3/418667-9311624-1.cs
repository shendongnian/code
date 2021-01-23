    [StructLayout(LayoutKind.Sequential)]
    public struct Rgb16 {
        private readonly UInt16 raw;
        public byte R{get{return (byte)((raw>>0)&0x1F);}}
        public byte G{get{return (byte)((raw>>5)&0x3F);}}
        public byte B{get{return (byte)((raw>>11)&0x1F);}}
        public Rgb16(byte r, byte g, byte b)
        {
          Contract.Requires(r<0x20);
          Contract.Requires(g<0x40);
          Contract.Requires(b<0x20);
          raw=r|g<<5|b<<11;
        }
    }
