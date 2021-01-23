    [StructLayout(LayoutKind.Explicit, Size = 16, CharSet = CharSet.Ansi), Serializable]
    internal struct Header
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4)]
        [FieldOffset(0)]
        private char[] headerCharArray;
        public string header
        {
            get { return new string(headerCharArray); }
            set
            {
                if (value.Length == 4)
                {
                    headerCharArray = value.ToArray();
                }
                else
                {
                    throw new InvalidOperationException("String length was not 4.");
                }
            }
        }
        [FieldOffset(4)]
        public int version;
        [FieldOffset(8)]
        public int diroffset;
        [FieldOffset(12)]
        public int direntries;
    }
