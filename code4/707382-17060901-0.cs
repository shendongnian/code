    using System.Runtime.InteropServices;
    using System;
    namespace uti {
    public class Power {
        [DllImport("coredll.dll", EntryPoint = "KernelIoControl", SetLastError = true)]
        private static extern bool KernelIoControl(int dwIoControlCode, System.IntPtr lpInBuf, int nInBufSize, byte[] lpOutBuf, int nOutBufSize, ref int lpBytesReturned);
        private const int FILE_ANY_ACCESS = 0;
        private const int FILE_DEVICE_HAL = 257;
        private const int METHOD_BUFFERED = 0;
        private const int IOCTL_HAL_REBOOT = (FILE_DEVICE_HAL << 16) | (FILE_ANY_ACCESS << 14) | (15 << 2) | METHOD_BUFFERED;
        public static bool DeviceReset() {
            int cb = 0;
            return KernelIoControl(IOCTL_HAL_REBOOT, System.IntPtr.Zero, 0, null, 0, ref cb);
        }
        private struct SYSTEM_POWER_STATUS_EX {
            public byte ACLineStatus;
            public byte BatteryFlag;
            public byte BatteryLifePercent;
            public byte Reserved1;
            public uint BatteryLifeTime;
            public uint BatteryFullLifeTime;
            public byte Reserved2;
            public byte BackupBatteryFlag;
            public byte BackupBatteryLifePercent;
            public byte Reserved3;
            public uint BackupBatteryLifeTime;
            public uint BackupBatteryFullLifeTime;
        }
        [DllImport("coredll.dll")]
        extern static private bool GetSystemPowerStatusEx(ref SYSTEM_POWER_STATUS_EX sps);
        public enum enACLineStatus {
            Offline = 0,
            Online = 1,
            Backuppower = 2,
            Unknownstatus = 255
        }
        [FlagsAttribute]
        public enum enBatteryFlag {
            High = 1,
            Low = 2,
            Critical = 4,
            Charging = 8,
            Nosystembattery = 128,
            Unknownstatus = 255
        }
        static enACLineStatus _ACLineStatus = 0;
        public static enACLineStatus ACLineStatus {
            get {
                return _ACLineStatus;
            }
        }
        static enBatteryFlag _BatteryFlag = 0;
        public static enBatteryFlag BatteryFlag {
            get {
                return _BatteryFlag;
            }
        }
        static byte _BatteryLifePercent = 0;
        public static byte BatteryLifePercent {
            get {
                return _BatteryLifePercent;
            }
        }
        static byte _Reserved1 = 0;
        public static byte Reserved1 {
            get {
                return _Reserved1;
            }
        }
        static uint _BatteryLifeTime = 0;
        public static uint BatteryLifeTime {
            get {
                return _BatteryLifeTime;
            }
        }
        static uint _BatteryFullLifeTime = 0;
        public static uint BatteryFullLifeTime {
            get {
                return _BatteryFullLifeTime;
            }
        }
        static byte _Reserved2 = 0;
        public static byte Reserved2 {
            get {
                return _Reserved2;
            }
        }
        static enBatteryFlag _BackupBatteryFlag = 0;
  
        public static enBatteryFlag BackupBatteryFlag {
            get {
                return _BackupBatteryFlag;
            }
        }
        static byte _BackupBatteryLifePercent = 0;
        public static byte BackupBatteryLifePercent {
            get {
                return _BackupBatteryLifePercent;
            }
        }
        static byte _Reserved3 = 0;
        public static byte Reserved3 {
            get {
                return _Reserved3;
            }
        }
        static uint _BackupBatteryLifeTime = 0;
        public static uint BackupBatteryLifeTime {
            get {
                return _BackupBatteryLifeTime;
            }
        }
        static uint _BackupBatteryFullLifeTime = 0;
        public static uint BackupBatteryFullLifeTime {
            get {
                return _BackupBatteryFullLifeTime;
            }
        }
        public static void Refresh() {
            SYSTEM_POWER_STATUS_EX sps = new SYSTEM_POWER_STATUS_EX();
            bool bRet = GetSystemPowerStatusEx(ref sps);
            if (!bRet)
                return;
            _ACLineStatus =
                (enACLineStatus)
                sps.ACLineStatus;
            _BatteryFlag =
                (enBatteryFlag)
                sps.BatteryFlag;
            _BatteryLifePercent =
                sps.BatteryLifePercent;
            _Reserved1 =
                sps.Reserved1;
            _BatteryLifeTime =
                sps.BatteryLifeTime;
            _BatteryFullLifeTime =
                sps.BatteryFullLifeTime;
            _Reserved2 =
                sps.Reserved2;
            _BackupBatteryFlag =
                (enBatteryFlag)
                sps.BackupBatteryFlag;
            _BackupBatteryLifePercent =
                sps.BackupBatteryLifePercent;
            _Reserved3 =
                sps.Reserved3;
            _BackupBatteryLifeTime =
                sps.BackupBatteryLifeTime;
            _BackupBatteryFullLifeTime =
                sps.BackupBatteryFullLifeTime;
        }
		[DllImport("coredll.dll", SetLastError = true)]
		static extern int SetSystemPowerState(string psState, int StateFlags, int    Options);
		const int POWER_STATE_ON = 0x00010000;
		const int POWER_STATE_OFF = 0x00020000;
		const int POWER_STATE_SUSPEND = 0x00200000;
		const int POWER_FORCE = 4096;
		const int POWER_STATE_RESET = 0x00800000;
       }
     }
