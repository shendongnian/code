      [StructLayout(LayoutKind.Sequential, Pack = 1)]
      public class SYSTEM_HANDLE_TABLE_ENTRY_INFO_EX
      {
        public IntPtr Object;
        public IntPtr UniqueProcessId;
        public IntPtr HandleValue;
        public uint GrantedAccess;
        public ushort CreatorBackTraceIndex;
        public ushort ObjectTypeIndex;
        public uint HandleAttributes;
        public uint Reserved;
      }
      internal enum SYSTEM_INFORMATION_CLASS
      {
        SystemBasicInformation = 0,
        SystemPerformanceInformation = 2,
        SystemTimeOfDayInformation = 3,
        SystemProcessInformation = 5,
        SystemProcessorPerformanceInformation = 8,
        SystemHandleInformation = 16,
        SystemInterruptInformation = 23,
        SystemExceptionInformation = 33,
        SystemRegistryQuotaInformation = 37,
        SystemLookasideInformation = 45,
        SystemExtendedHandleInformation = 64,
      }
     [DllImport("ntdll.dll", CharSet=CharSet.Auto)]
     private static extern int NtQuerySystemInformation(int InfoType, IntPtr lpStructure, int StructSize, out int returnLength);
      public static void Main(string[] args)
      {
        Console.WriteLine(Environment.Is64BitProcess ? "x64" : "x32");
        Console.WriteLine();
        var infoSize = Marshal.SizeOf(typeof(SYSTEM_HANDLE_TABLE_ENTRY_INFO_EX));
        Console.WriteLine("sizeof(SYSTEM_HANDLE_TABLE_ENTRY_INFO_EX): {0}", infoSize);
        int allSize = 1000 * infoSize;
        var buffer = Marshal.AllocHGlobal(allSize);
        var status = NtQuerySystemInformation((int)SYSTEM_INFORMATION_CLASS.SystemExtendedHandleInformation, buffer, allSize, out allSize);
        Console.WriteLine("status: {0:x}, return len: {1}", status, allSize);
        if (status != 0)
        {
          allSize += 40 * infoSize;
          Marshal.FreeHGlobal(buffer);
          buffer = Marshal.AllocHGlobal(allSize);
          status = NtQuerySystemInformation((int)SYSTEM_INFORMATION_CLASS.SystemExtendedHandleInformation, buffer, allSize, out allSize);
          Console.WriteLine("status: {0:x}, return len: {1}", status, allSize);
        }
        Console.WriteLine();
        var info = new SYSTEM_HANDLE_TABLE_ENTRY_INFO_EX();
        //for (var i = 0; i < allSize; i += infoSize)
        for (var i = 0; i < Math.Min(allSize, 20 * infoSize); i+= infoSize) // for testing purpose only 20
        {
          Marshal.PtrToStructure(IntPtr.Add(buffer, i), info);
          Console.WriteLine("{0,16:x}, {1,16:x}, {2,16:x}, {3,6:x}, {4,8:x}", info.Object.ToInt64(), info.UniqueProcessId.ToInt64(), info.HandleValue.ToInt64(), info.GrantedAccess, info.HandleAttributes);
        }
        Marshal.FreeHGlobal(buffer);
      }
