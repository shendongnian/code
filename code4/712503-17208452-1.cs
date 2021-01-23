    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System;
    using System.Diagnostics;
    static class Nat
    {
        struct IO_COUNTERS
        {
            public ulong ReadOperationCount;
            public ulong WriteOperationCount;
            public ulong OtherOperationCount;
            public ulong ReadTransferCount;
            public ulong WriteTransferCount;
            public ulong OtherTransferCount;
        }
        [DllImport("kernel32.dll")]
        unsafe static extern bool GetProcessIoCounters(IntPtr* ProcessHandle, out IO_COUNTERS* IoCounters);
        
        [StructLayout(LayoutKind.Sequential, Size = 40)]
        private struct PROCESS_MEMORY_COUNTERS
        {
            public uint cb;
            public uint PageFaultCount;
            public uint PeakWorkingSetSize;
            public uint WorkingSetSize;
            public uint QuotaPeakPagedPoolUsage;
            public uint QuotaPagedPoolUsage;
            public uint QuotaPeakNonPagedPoolUsage;
            public uint QuotaNonPagedPoolUsage;
            public uint PagefileUsage;
            public uint PeakPagefileUsage;
        }
        
        [DllImport("psapi.dll", SetLastError = true)]
        unsafe static extern bool GetProcessMemoryInfo(IntPtr* hProcess, out PROCESS_MEMORY_COUNTERS* Memcounters, int size);
        
        public static class IO
        {
            unsafe public static Dictionary<string, ulong> GetALLIO(Process procToRtrivIO)
            {
                IO_COUNTERS* counters;
                Dictionary<string, ulong> retCountIoDict = new Dictionary<string, ulong>();
                IntPtr ptr = System.Diagnostics.Process.GetCurrentProcess().Handle;
        
                GetProcessIoCounters(&ptr, out counters);
                retCountIoDict.Add("ReadOperationCount", counters->ReadOperationCount);
                retCountIoDict.Add("WriteOperationCount", counters->WriteOperationCount);
                retCountIoDict.Add("OtherOperationCount", counters->OtherOperationCount);
                retCountIoDict.Add("ReadTransferCount", counters->ReadTransferCount);
                retCountIoDict.Add("WriteTransferCount", counters->WriteTransferCount);
                retCountIoDict.Add("OtherTransferCount", counters->OtherTransferCount);
                return retCountIoDict;
                //return  "This process has read " + ((counters.ReadTransferCount/1024)/1024).ToString("N0") +
                //    " Mb of data.";
        
            }
        }
        public static class Mem
        {
            unsafe public static Dictionary<string, uint> GetAllMem(Process procToRtrivMem)
            {
        
                PROCESS_MEMORY_COUNTERS* MemCounters;
                Dictionary<string, uint> retCountMemDict = new Dictionary<string, uint>();
                IntPtr ptr = System.Diagnostics.Process.GetCurrentProcess().Handle;
        
                GetProcessMemoryInfo(&ptr, out MemCounters, Marshal.SizeOf(typeof(PROCESS_MEMORY_COUNTERS))); //MemCounters.cb);
                retCountMemDict.Add("cb", MemCounters->cb);
                retCountMemDict.Add("PageFaultCount", MemCounters->PageFaultCount);
                retCountMemDict.Add("PeakWorkingSetSize", MemCounters->PeakWorkingSetSize);
                retCountMemDict.Add("WorkingSetSize", MemCounters->WorkingSetSize);
                retCountMemDict.Add("QuotaPeakPagedPoolUsage", MemCounters->QuotaPeakPagedPoolUsage);
                retCountMemDict.Add("QuotaPagedPoolUsage", MemCounters->QuotaPagedPoolUsage);
        
                retCountMemDict.Add("QuotaPeakNonPagedPoolUsage", MemCounters->QuotaPeakNonPagedPoolUsage);
                retCountMemDict.Add("QuotaNonPagedPoolUsage", MemCounters->QuotaNonPagedPoolUsage);
                retCountMemDict.Add("PagefileUsage", MemCounters->PagefileUsage);
                retCountMemDict.Add("PeakPagefileUsage", MemCounters->PeakPagefileUsage);
        
                return retCountMemDict;
                //return  "This process has read " + ((counters.ReadTransferCount/1024)/1024).ToString("N0") +
                //    " Mb of data.";
        
            }
        }
    }
