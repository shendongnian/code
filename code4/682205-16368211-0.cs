        [DllImport("kernel32.dll")]
        public static extern Int32 ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesRead);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten);
        public static byte[] ReadMem(IntPtr MemAddy, uint bytestoread, Process Proc)
        {
            //
            //Create new Memory buffer and pointer to that buffer
            //
            byte[] buffer = new byte[bytestoread];
            IntPtr bufferptr;
            //
            //Read Process Memory and output to buffer
            //
            ReadProcessMemory(Proc.Handle, MemAddy, buffer, bytestoread, out bufferptr);
            //
            //Return the buffer
            //
            return buffer;
        }
        public static bool WriteMem(IntPtr MemAddy, byte[] buffer, Process Proc)
        {
            int NumWriten;
            WriteProcessMemory(Proc.Handle, MemAddy, buffer, (uint)buffer.Length, out NumWriten);
            if (NumWriten != buffer.Length)
            {
                return false;
            }
            else return true;
        }
