    public static class NativeTest
    {
        private const string DllFilePath = @"c:\pathto\mydllfile.dll";
        [DllImport(DllFilePath , CallingConvention = CallingConvention.Cdecl)]
        private extern static int test(int number);
        public static int Test(int number)
        {
            return test(number);
        }
    }
