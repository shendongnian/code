    using System;
    using System.Runtime.InteropServices;
    using System.Security.Principal;
    public static class MemoryUtility
    {
       private static void ClearStandbyCache()
       {
         SetIncreasePrivilege(SE_PROFILE_SINGLE_PROCESS_NAME);
         int iReturn;
         int iSize = Marshal.SizeOf(ClearStandbyPageList);
         GCHandle gch = GCHandle.Alloc(ClearStandbyPageList, GCHandleType.Pinned);
         iReturn = NtSetSystemInformation(SYSTEMMEMORYLISTINFORMATION, gch.AddrOfPinnedObject(), iSize);
         gch.Free();
         if (iReturn != 0)
           Console.WriteLine("Empty Standby List failed");
         else
           Console.WriteLine("Empty Standby List success");
       }
  
 
       [DllImport("NTDLL.dll", SetLastError = true)]
       internal static extern int NtSetSystemInformation(int SystemInformationClass, IntPtr SystemInfo, int SystemInfoLength);
       //SystemInformationClass values
       private static int SYSTEMCACHEINFORMATION = 0x15;
       private static int SYSTEMMEMORYLISTINFORMATION = 80;
       //SystemInfo values
       private static int ClearStandbyPageList = 4;
    }
