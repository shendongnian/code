    public struct LocalTestInfo
    {
        public int TestId;
        public IEnumerable<string> Parameters;
    
        public static explicit operator TestInfo(LocalTestInfo info)
        {
            var marshalled = new TestInfo
                {
                    TestId = info.TestId, 
                };
            var paramsArray = info.Parameters
                .Select(Marshal.StringToHGlobalAnsi)
                .ToArray();
            marshalled.pinnedHandle = GCHandle.Alloc(
                paramsArray, 
                GCHandleType.Pinned);
            marshalled.Parameters = 
                marshalled.pinnedHandle.AddrOfPinnedObject();
            return marshalled;
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct TestInfo : IDisposable
    {
        public int TestId;
        public IntPtr Parameters;
    
        [NonSerialized]
        public GCHandle pinnedHandle;
    
        public void Dispose()
        {
            if (pinnedHandle.IsAllocated)
            {
                Console.WriteLine("Freeing pinned handle");
                var paramsArray = (IntPtr[])this.pinnedHandle.Target;
                foreach (IntPtr ptr in paramsArray)
                {
                    Console.WriteLine("Freeing @ " + ptr);
                    Marshal.FreeHGlobal(ptr);
                }
                pinnedHandle.Free();
            }
        }
    }
