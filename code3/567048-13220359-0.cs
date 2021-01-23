        /// <summary>
    /// Wrapper class for Win32 API calls
    /// </summary>
    public class NativeMethods
    {
        [DllImport("shell32.dll", SetLastError = true)]
        static extern IntPtr CommandLineToArgvW(
            [MarshalAs(UnmanagedType.LPWStr)] string lpCmdLine, out int pNumArgs);
        /// <summary>
        /// Parse a string into an array, including items in quotes
        /// </summary>
        /// <param name="commandLine"></param>
        /// <returns></returns>
        public static string[] CommandLineToArgs(string commandLine)
        {
            if (String.IsNullOrEmpty(commandLine))
                return new string[] {};
            int argc;
            var argv = CommandLineToArgvW(commandLine, out argc);
            if (argv == IntPtr.Zero)
                throw new System.ComponentModel.Win32Exception();
            try
            {
                var args = new string[argc];
                for (var i = 0; i < args.Length; i++)
                {
                    var p = Marshal.ReadIntPtr(argv, i * IntPtr.Size);
                    args[i] = Marshal.PtrToStringUni(p);
                }
                return args;
            }
            finally
            {
                Marshal.FreeHGlobal(argv);
            }
        }
    }
