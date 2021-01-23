        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct NestedStruct
        {
            public Int16 someInt;
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 242)]
            public Byte[] characterArray; // an array of fixed length 242
        }
         [StructLayout(LayoutKind.Sequential, Pack = 1)]
         public struct OtherNestedStruct
         {
             public Int16 someInt;
             public Int16 someOtherInt;
         }
         [StructLayout(LayoutKind.Sequential, Pack = 1)]
         public struct MainStruct
         {
             public double someDouble;
             public NestedStruct nestedContent;
             [MarshalAs(UnmanagedType.ByValArray, SizeConst = 13 * 4)]
             public OtherNestedStruct[] arrayOfStruct; // fixed array length 13
        }  
      
        static void Main(string[] args)
        {
            var x = Marshal.SizeOf(typeof(MainStruct));
            //x == 460
        } 
