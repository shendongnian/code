    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
     public struct DEVMGR_DEVICE_INFORMATION
     {
      public uint dwSize;
      public IntPtr hDevice;
      public IntPtr hParentDevice;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
      public string szLegacyName;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
      public string szDeviceKey;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
      public string szDeviceName;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
      public string szBusName;
    }
    public enum DeviceSearchType : int
    {
      DeviceSearchByLegacyName = 0,
      DeviceSearchByDeviceName = 1,
      DeviceSearchByBusName = 2,
      DeviceSearchByGuid = 3,
      DeviceSearchByParent = 4
    }
    class DevDriverInterface
    {
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
      public struct SECURITY_ATTRIBUTES
      {
         public int nLength;
         public IntPtr lpSecurityDescriptor;
         public bool bInheritHandle;
      }
      [DllImport("coredll.dll", SetLastError = true)]
      public extern static int ActivateDeviceEx(string device, IntPtr regEnts,
         UInt32 cRegEnts, IntPtr devKey);
      [DllImport("coredll.dll", SetLastError = true)]
      public extern static bool DeactivateDevice(int handle);
      [DllImport("coredll.dll", SetLastError = true)]
      public static extern int FindFirstDevice(DeviceSearchType
      searchType, IntPtr searchParam, ref DEVMGR_DEVICE_INFORMATION pdi);
 
      // Constructor
      public DevDriverInterface() { }
      public bool MountSDCardDrive()
      {
         const int INVALID_HANDLE_VALUE = -1;
         string mRegPath1 = "";
         int handle = INVALID_HANDLE_VALUE;
         DeviceSearchType searchType = DeviceSearchType.DeviceSearchByDeviceName;
         DEVMGR_DEVICE_INFORMATION di = new DEVMGR_DEVICE_INFORMATION();
         di.dwSize = (uint)Marshal.SizeOf(typeof(DEVMGR_DEVICE_INFORMATION));
         String searchParamString = "SDH1";
         
         IntPtr searchParam = Marshal.StringToBSTR(searchParamString);
         handle = FindFirstDevice(searchType, searchParam, ref di);
         
         if (handle == INVALID_HANDLE_VALUE)
         {
            // Failure - print error
            int hFindFirstDeviceError = Marshal.GetLastWin32Error();
            using (StreamWriter bw = new StreamWriter(File.Open(App.chipDebugFile, 
                FileMode.Append)))
            {
               String iua = "DevDriverInterface: error from FindFirstDevice: " + 
                      hFindFirstDeviceError.ToString();
               bw.WriteLine(iua);
            }
            return false;
         }
         else
         {
            mRegPath1 = di.szDeviceKey;
            bool deactBool = DeactivateDevice((int) di.hDevice);
            if (deactBool == false)
            {
               using (StreamWriter bw = new StreamWriter(File.Open(App.chipDebugFile,
                  FileMode.Append)))
               {
                  String iua = "DevDriverInterface: DeactivateDevice: returned false -
                              FAILED";
                  bw.WriteLine(iua);
               }
               return false;
            }
            Thread.Sleep(50);
            // Call ActiveDevice to setup the device driver
            handle = ActivateDeviceEx(mRegPath1, IntPtr.Zero, 0, IntPtr.Zero);
            if (handle == INVALID_HANDLE_VALUE)
            {
               // Failure - print error
               int hActivateDeviceError = Marshal.GetLastWin32Error();
              
               using (StreamWriter bw = new StreamWriter(File.Open(App.chipDebugFile, 
                  FileMode.Append)))
               {
                  String iua = "DevDriverInterface: error from ActivateDevice: " + 
                         hActivateDeviceError.ToString();
                  bw.WriteLine(iua);
               }
               return false;
            }
 
         }
         return true;
      }
    }; // end class
