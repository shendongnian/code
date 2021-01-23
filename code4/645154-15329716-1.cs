    using System.Runtime.InteropServices;
    using Microsoft.Win32; 
    namespace ConsoleApplication1
    {
        class Program
        {
        [DllImport("Advapi32.dll")]
        public static extern int RegLoadKey(uint hKey, string lpSubKey, string lpFile);
        [DllImport("Advapi32.dll")]
        public static extern int RegUnLoadKey(uint hKey, string lpSubKey);
        static void Main(string[] args)
        {
            uint HKLM = 0x80000002;
            string tmpHive = "offlineSystemHive";
            string offlineHive = "E:\\Windows\\system32\\config\\SYSTEM";
            RegLoadKey(HKLM, tmpHive, offlineHive);
            RegistryKey baseKey = Registry.LocalMachine.OpenSubKey("offlineSystemHive\\SYSTEM\\ControlSet001\\Control\\ComputerName\\ComputerName");
            Console.WriteLine(baseKey.GetValue("ComputerName"));
            RegUnLoadKey(HKLM, tmpHive);
        }
    }
    
