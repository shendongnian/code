        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct NestedStruct
        {
            public Int16 someInt;
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 242)]
            public Byte[] characterArray; // an array of fixed length 242
        }
        
        
        static void Main(string[] args)
        {
            var x = Marshal.SizeOf(typeof (NestedStruct));
            //x == 244
        }
