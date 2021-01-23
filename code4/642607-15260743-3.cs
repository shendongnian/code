        static void Splode()
        {
            var myProcess = Process.GetCurrentProcess();
            var hProcess = myProcess.Handle;
            var rnd = new Random();
            while (true)
            {
                var writeTo = new IntPtr((int)rnd.Next(0, int.MaxValue));
                var toWrite = new byte[1024];
                UIntPtr written;
                WriteProcessMemory(
                    hProcess,
                    writeTo,
                    toWrite,
                    (uint)toWrite.Length,
                    out written);
            }            
        }
