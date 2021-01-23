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
            //Use stopwatch when benchmarking, not DateTime
            Stopwatch stopwatch = new Stopwatch();
            
            stopwatch.Start();
            using (FileStream fs = File.Create(@"e:\Test\test.dat"))
            {
                MarkAsSparseFile(fs.SafeFileHandle);
                fs.SetLength(1024 * 1024 * 100);
                fs.Seek(-1, SeekOrigin.End);
                fs.WriteByte(255);
            }
            stopwatch.Stop();
            //Returns 2 for sparse files and 1127 for non sparse
            Console.WriteLine(@"WRITE MS: " + stopwatch.ElapsedMilliseconds); 
        }
    }
