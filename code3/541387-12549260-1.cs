    [StructLayout(LayoutKind.Sequential)]
    public struct UInt24 {
        private Byte _b0;
        private Byte _b1;
        private Byte _b2;
        
        public UInt24(UInt32 value) {
            _b0 = (byte)( (value      ) & 0xFF );
            _b1 = (byte)( (value >>  8) & 0xFF ); 
            _b2 = (byte)( (value >> 16) & 0xFF );
        }
        
        public unsafe Byte* Byte0 { get { return &_b0; } }
        public UInt32 Value { get { return _b0 | ( _b1 << 8 ) | ( _b2 << 16 ); } }
    }
    // Usage:
    
    [DllImport("foo.dll")]
    public static unsafe void SomeImportedFunction(byte* uint24Value);
    
    UInt24 uint24 = new UInt24( 123 );
    SomeImportedFunction( uint24.Byte0 );
