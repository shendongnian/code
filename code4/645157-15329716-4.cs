    using System.Runtime.InteropServices;
    using Microsoft.Win32; 
    namespace ConsoleApplication1
    {
        class Program
        {
        [DllImport("advapi32.dll")]
        public static extern int RegLoadKey(uint hKey, string lpSubKey, string lpFile);
        [DllImport("advapi32.dll")]
        public static extern int RegUnLoadKey(uint hKey, string lpSubKey);
        [DllImport("advapi32.dll")]
        public static extern int OpenProcessToken(int ProcessHandle, int DesiredAccess, ref int tokenhandle);
        [DllImport("kernel32.dll")]
        public static extern int GetCurrentProcess();
        [DllImport("advapi32.dll")]
        public static extern int AdjustTokenPrivileges(int tokenhandle, int disableprivs, [MarshalAs(UnmanagedType.Struct)]ref TOKEN_PRIVILEGES Newstate, int bufferlength, int PreivousState, int Returnlength);
        [DllImport("advapi32.dll")]
        public static extern int LookupPrivilegeValue(string lpsystemname, string lpname, [MarshalAs(UnmanagedType.Struct)] ref LUID lpLuid);
        [StructLayout(LayoutKind.Sequential)]
        public struct LUID
        {
            public int LowPart;
            public int HighPart;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct TOKEN_PRIVILEGES
        {
            public LUID Luid;
            public int Attributes;
            public int PrivilegeCount;
        }
        static void Main(string[] args)
        {
            int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
            int SE_PRIVILEGE_ENABLED = 0x00000002;
            int TOKEN_QUERY = 0x00000008;
            int token = 0;
            int retval = 0;
            uint HKU = 0x80000003;
            string SE_BACKUP_NAME = "SeBackupPrivilege";
            string SE_RESTORE_NAME = "SeRestorePrivilege";
            string tmpHive = "offlineSystemHive";
            string offlineHive = "E:\\Windows\\system32\\config\\SYSTEM";
            
            LUID RestoreLuid = new LUID();
            LUID BackupLuid = new LUID();
            TOKEN_PRIVILEGES TP = new TOKEN_PRIVILEGES();
            TOKEN_PRIVILEGES TP2 = new TOKEN_PRIVILEGES();
            retval = OpenProcessToken(GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, ref token);
            retval = LookupPrivilegeValue(null, SE_RESTORE_NAME, ref RestoreLuid);
            retval = LookupPrivilegeValue(null, SE_BACKUP_NAME, ref BackupLuid);
            TP.PrivilegeCount = 1;
            TP.Attributes = SE_PRIVILEGE_ENABLED;
            TP.Luid = RestoreLuid;
            TP2.PrivilegeCount = 1;
            TP2.Attributes = SE_PRIVILEGE_ENABLED;
            TP2.Luid = BackupLuid;
            retval = AdjustTokenPrivileges(token, 0, ref TP, 1024, 0, 0);
            retval = AdjustTokenPrivileges(token, 0, ref TP2, 1024, 0, 0);
            int rtnVal = RegLoadKey(HKU, tmpHive, offlineHive);
            Console.WriteLine(rtnVal); //should be 0
            RegistryKey baseKey = Registry.Users.OpenSubKey("offlineSystemHive\\ControlSet001\\Control\\ComputerName\\ComputerName");
            Console.WriteLine(baseKey.GetValue("ComputerName"));
            baseKey.Close();
            rtnVal = RegUnLoadKey(HKU, tmpHive);
            Console.WriteLine(rtnVal); //should be 0
        }
    }
    }
    
