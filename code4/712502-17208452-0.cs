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
