    ⁄⁄ needed to import the .dll
    using System.Runtime.InteropServices;
    
        public class USBm
            {
            public static byte BitA0 = 0x00;
            public static byte BitA1 = 0x01;
            public static byte BitA2 = 0x02;
            public static byte BitA3 = 0x03;
            public static byte BitA4 = 0x04;
            public static byte BitA5 = 0x05;
            public static byte BitA6 = 0x06;
            public static byte BitA7 = 0x07;
            public static byte BitB0 = 0x08;
            public static byte BitB1 = 0x09;
            public static byte BitB2 = 0x0A;
            public static byte BitB3 = 0x0B;
            public static byte BitB4 = 0x0C;
            public static byte BitB5 = 0x0D;
            public static byte BitB6 = 0x0E;
            public static byte BitB7 = 0x0F;
    
    ⁄⁄  USBm.dll - C# pInvoke examples
    ⁄⁄  "Commands"
    ⁄⁄      [DllImport("USBm.dll", EntryPoint = "USBm_FindDevices", CharSet = CharSet.Auto)]
            [DllImport("USBm.dll")]
            public static extern bool USBm_FindDevices();
            [DllImport("USBm.dll")]
            public static extern int USBm_NumberOfDevices();
            [DllImport("USBm.dll")]
            public static extern bool USBm_DeviceValid(int Device);
            [DllImport("USBm.dll")]
            public static extern bool USBm_About(StringBuilder About);
            [DllImport("USBm.dll")]
            public static extern bool USBm_Version(StringBuilder Version);
            [DllImport("USBm.dll")]
            public static extern bool USBm_Copyright(StringBuilder Copyright);
            [DllImport("USBm.dll")]
            public static extern bool USBm_DeviceMfr(int Device, StringBuilder Mfr);
            [DllImport("USBm.dll")]
            public static extern bool USBm_DeviceProd(int Device, StringBuilder Prod);
            [DllImport("USBm.dll")]
            public static extern int USBm_DeviceFirmwareVer(int Device);
            [DllImport("USBm.dll")]
            public static extern bool USBm_DeviceSer(int Device, StringBuilder dSer);
            [DllImport("USBm.dll")]
            public static extern int USBm_DeviceDID(int Device);
            [DllImport("USBm.dll")]
            public static extern int USBm_DevicePID(int Device);
            [DllImport("USBm.dll")]
            public static extern int USBm_DeviceVID(int Device);
            [DllImport("USBm.dll")]
            public static extern bool USBm_DebugString(StringBuilder DBug);
            [DllImport("USBm.dll")]
            public static extern bool USBm_RecentError(StringBuilder rError);
            [DllImport("USBm.dll")]
            public static extern bool USBm_ClearRecentError();
            [DllImport("USBm.dll")]
            public static extern bool USBm_SetReadTimeout(uint TimeOut);
            [DllImport("USBm.dll")]
            public static extern bool USBm_ReadDevice(int Device, byte[] inBuf);
            [DllImport("USBm.dll")]
            public static extern bool USBm_WriteDevice(int Device, byte[] outBuf);
            [DllImport("USBm.dll")]
            public static extern bool USBm_CloseDevice(int Device);
            }
