    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Test
    {
        private long dt1; 
        public byte b;
        public Int64 int1;
        public float f1;
        public float f2;
        public float f3;
        public DateTime DT
        {
            get { return new DateTime(dt1); }
            set { dt1 = value.Ticks; }
        }
    }
