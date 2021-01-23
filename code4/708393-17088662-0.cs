    [StructLayout(LayoutKind.Sequential)]
    public struct Token {
        public Range location;
        public TokenType type;
        [MarshalAs(UnmanagedType.LPStr)]
        public string value;
    }
