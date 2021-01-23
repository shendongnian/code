    /// <summary>
    /// A utility class to determine a process parent.
    /// </summary>
    /// <remarks>
    /// From https://stackoverflow.com/a/3346055/240845
    /// </remarks>
    public static class ParentProcessUtilities
    {
        /// <summary>
        /// Gets the parent process.
        /// </summary>
        /// <param name="process">The process to get the parent of</param>
        /// <returns>The parent process.</returns>
        public static Process Parent(this Process process)
        {
            return GetParentProcess(process.Handle);
        }
        /// <summary>
        /// Gets the parent process of the current process.
        /// </summary>
        /// <returns>An instance of the Process class.</returns>
        public static Process GetParentProcess()
        {
            return Process.GetCurrentProcess().Parent();
        }
        /// <summary>
        /// Gets the parent process of a specified process.
        /// </summary>
        /// <param name="handle">The process handle.</param>
        /// <returns>The parent process.</returns>
        public static Process GetParentProcess(IntPtr handle)
        {
            ProcessInformation pbi = new ProcessInformation();
            // Note, according to Microsoft, this usage of NtQueryInformationProcess is 
            // unsupported and may change
            int status = NtQueryInformationProcess(
                handle, 0, ref pbi, Marshal.SizeOf(pbi), out _);
            if (status != 0)
            {
                throw new Win32Exception(status);
            }
            try
            {
                return Process.GetProcessById(pbi.InheritedFromUniqueProcessId.ToInt32());
            }
            catch (ArgumentException)
            {
                // not found
                return null;
            }
        }
        [DllImport("ntdll.dll")]
        private static extern int NtQueryInformationProcess(
            IntPtr processHandle, int processInformationClass,
            ref ProcessInformation processInformation, int processInformationLength, 
            out int returnLength);
        /// <summary>
        /// Used in the NtQueryInformationProcess call.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct ProcessInformation
        {
            // These members must match PROCESS_BASIC_INFORMATION
            internal IntPtr Reserved1;
            internal IntPtr PebBaseAddress;
            internal IntPtr Reserved2_0;
            internal IntPtr Reserved2_1;
            internal IntPtr UniqueProcessId;
            internal IntPtr InheritedFromUniqueProcessId;
        }
    }
