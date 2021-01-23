    public static class ProcessExtensions
    {
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, ref bool isDebuggerPresent);
        public static bool IsDebuggerAttached(this Process process)
        {
            try
            {
                var isDebuggerAttached = false;
                CheckRemoteDebuggerPresent(process.Handle, ref isDebuggerAttached);
                return isDebuggerAttached;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
