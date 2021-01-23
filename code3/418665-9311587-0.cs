    public struct Rgb16 {
        public ushort Value; // two byte value that internally contain structure R(4):G(5):B(4)
    
        public Rgb16BitField GetBitField
        {
            get; set;
        }
    }
