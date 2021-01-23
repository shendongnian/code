    public class WrapperClass
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct TestA
        {
            public int i;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 512)]
            public string text;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct TestB
        {
            public double n;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 512)]
            public string text;
        }
        public struct TestUnion  // Removed marshal attributes since they cause exceptions
        {
            public TestA a;
            public TestB b;
        }
        [DllImport("UnmanagedDLL.Dll")]
        private static extern int fnUnmanagedDLL(int which, IntPtr obj);
        public static int UnmanagedDLL(int which, ref TestUnion testUnion) {
           IntPtr buffer = Marshal.AllocHGlobal(
                    Math.Max(Marshal.SizeOf(typeof(TestA)),
                             Marshal.SizeOf(typeof(TestB)));
           
           int returnType = fnUnmanagedDLL(which, buffer);
           switch (returnType) {
               case 1: // What ever fnUnmanagedDLL returns for TestA
                  testUnion.a = (TestA)Marshal.PtrToStructure(buffer, typeof(TestA));
                  break;
               case 2: // What ever fnUnmanagedDLL returns for TestB
                  testUnion.a = (TestB)Marshal.PtrToStructure(buffer, typeof(TestB));
                  break;
           }
           Marhsal.FreeHGlobal(buffer); // Need to manually free the allocated buffer
           
           return returnType;
        }
    }
