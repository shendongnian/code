    class Program
    {
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool DeviceIoControl(
            SafeFileHandle hDevice,
            int dwIoControlCode,
            IntPtr InBuffer,
            int nInBufferSize,
            IntPtr OutBuffer,
            int nOutBufferSize,
            ref int pBytesReturned,
            [In] ref NativeOverlapped lpOverlapped
        );
        static void MarkAsSparseFile(SafeFileHandle fileHandle)
        {
            int bytesReturned = 0;
            NativeOverlapped lpOverlapped = new NativeOverlapped();
            bool result =
                DeviceIoControl(
                    fileHandle,
                    590020, //FSCTL_SET_SPARSE,
                    IntPtr.Zero,
                    0,
                    IntPtr.Zero,
                    0,
                    ref bytesReturned,
                    ref lpOverlapped);
            if(result == false)
                throw new Win32Exception();
        }
        static void Main()
        {
            string filename = @"e:\Test\test.dat";
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                MarkAsSparseFile(fs.SafeFileHandle); //This can be done to existing files too, you don't need to use FileMode.Create.
                fs.Seek(1024 * 1024 * 100, SeekOrigin.Begin);
                fs.WriteByte(1);
            }
        }
    }
