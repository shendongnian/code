        internal static class UnsafeNativeMethods
        {
            const string _dllLocation = "..\\..\\..\\FinalTest\\debug\\finalTest.dll";
            [DllImport(_dllLocation, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
            public static extern IntPtr OnDecryption(string ksn, String bdk );
            static public byte[] OnDecryptionWrapper(string ksn, string bdk)
            {
                byte[] data = new byte[10];
                IntPtr ptr = OnDecryption(ksn, bdk);
                Marshal.Copy(ptr, data, 0, 10);
                return data;
            }
        }
