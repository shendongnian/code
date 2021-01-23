    namespace MemoryInfo
    {
    
    
        class Program
        {
    
            static void Main(string[] args)
            {
                System.Diagnostics.Process proc = System.Diagnostics.Process.GetCurrentProcess();
                Nat.Mem.GetAllMem(proc);
                Nat.IO.GetALLIO(proc);
            }
        }
    
    
    
        // http://www.pinvoke.net/default.aspx/psapi.getprocessmemoryinfo
        static class Nat
        {
    
    
            // [DllImport("kernel32.dll")]
            // public static extern IntPtr GetCurrentProcess();
    
            [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
            private struct IO_COUNTERS
            {
                public ulong ReadOperationCount;
                public ulong WriteOperationCount;
                public ulong OtherOperationCount;
                public ulong ReadTransferCount;
                public ulong WriteTransferCount;
                public ulong OtherTransferCount;
            }
    
    
            [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Size = 40)]
            private struct PROCESS_MEMORY_COUNTERS
            {
                public uint cb; // The size of the structure, in bytes (DWORD).
                public uint PageFaultCount; // The number of page faults (DWORD).
                public uint PeakWorkingSetSize; // The peak working set size, in bytes (SIZE_T).
                public uint WorkingSetSize; // The current working set size, in bytes (SIZE_T).
                public uint QuotaPeakPagedPoolUsage; // The peak paged pool usage, in bytes (SIZE_T).
                public uint QuotaPagedPoolUsage; // The current paged pool usage, in bytes (SIZE_T).
                public uint QuotaPeakNonPagedPoolUsage; // The peak nonpaged pool usage, in bytes (SIZE_T).
                public uint QuotaNonPagedPoolUsage; // The current nonpaged pool usage, in bytes (SIZE_T).
                public uint PagefileUsage; // The Commit Charge value in bytes for this process (SIZE_T). Commit Charge is the total amount of memory that the memory manager has committed for a running process.
                public uint PeakPagefileUsage; // The peak value in bytes of the Commit Charge during the lifetime of this process (SIZE_T).
            }
    
    
            [System.Runtime.InteropServices.DllImport("kernel32.dll")]
            private unsafe static extern bool GetProcessIoCounters(System.IntPtr ProcessHandle, out IO_COUNTERS IoCounters);
    
            [System.Runtime.InteropServices.DllImport("psapi.dll", SetLastError = true)]
            private unsafe static extern bool GetProcessMemoryInfo(System.IntPtr hProcess, out PROCESS_MEMORY_COUNTERS counters, uint size);
    
    
            public static class IO
            {
                unsafe public static System.Collections.Generic.Dictionary<string, ulong> GetALLIO(System.Diagnostics.Process procToRtrivIO)
                {
                    IO_COUNTERS counters;
                    System.Collections.Generic.Dictionary<string, ulong> retCountIoDict = 
                        new System.Collections.Generic.Dictionary<string, ulong>();
                    System.IntPtr ptr = System.Diagnostics.Process.GetCurrentProcess().Handle;
    
                    GetProcessIoCounters(ptr, out counters);
                    retCountIoDict.Add("ReadOperationCount", counters.ReadOperationCount);
                    retCountIoDict.Add("WriteOperationCount", counters.WriteOperationCount);
                    retCountIoDict.Add("OtherOperationCount", counters.OtherOperationCount);
                    retCountIoDict.Add("ReadTransferCount", counters.ReadTransferCount);
                    retCountIoDict.Add("WriteTransferCount", counters.WriteTransferCount);
                    retCountIoDict.Add("OtherTransferCount", counters.OtherTransferCount);
                    return retCountIoDict;
                    //return  "This process has read " + ((counters.ReadTransferCount/1024)/1024).ToString("N0") +
                    //    " Mb of data.";
    
                }
            } // End Class IO 
    
    
            public static class Mem
            {
                unsafe public static System.Collections.Generic.Dictionary<string, uint> GetAllMem(System.Diagnostics.Process procToRtrivMem)
                {
                    PROCESS_MEMORY_COUNTERS MemCounters;
                    System.Collections.Generic.Dictionary<string, uint> retCountMemDict = 
                        new System.Collections.Generic.Dictionary<string, uint>();
                    System.IntPtr ptr = System.Diagnostics.Process.GetCurrentProcess().Handle;
                    uint nativeStructSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(PROCESS_MEMORY_COUNTERS));
    
    
                    GetProcessMemoryInfo(ptr, out MemCounters, nativeStructSize); //MemCounters.cb);
                    retCountMemDict.Add("cb", MemCounters.cb);
                    retCountMemDict.Add("PageFaultCount", MemCounters.PageFaultCount);
                    retCountMemDict.Add("PeakWorkingSetSize", MemCounters.PeakWorkingSetSize);
                    retCountMemDict.Add("WorkingSetSize", MemCounters.WorkingSetSize);
                    retCountMemDict.Add("QuotaPeakPagedPoolUsage", MemCounters.QuotaPeakPagedPoolUsage);
                    retCountMemDict.Add("QuotaPagedPoolUsage", MemCounters.QuotaPagedPoolUsage);
    
                    retCountMemDict.Add("QuotaPeakNonPagedPoolUsage", MemCounters.QuotaPeakNonPagedPoolUsage);
                    retCountMemDict.Add("QuotaNonPagedPoolUsage", MemCounters.QuotaNonPagedPoolUsage);
                    retCountMemDict.Add("PagefileUsage", MemCounters.PagefileUsage);
                    retCountMemDict.Add("PeakPagefileUsage", MemCounters.PeakPagefileUsage);
    
                    return retCountMemDict;
                    //return  "This process has read " + ((counters.ReadTransferCount/1024)/1024).ToString("N0") +
                    //    " Mb of data.";
                }
    
    
            } // End Class Mem
    
        }
    
    
    
    
    }
