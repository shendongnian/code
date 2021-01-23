    using System;
    using System.Runtime.InteropServices;
    
    public static class PowerInfo {
        public static int GetIdleTimeRemaining() {
            var info = new SYSTEM_POWER_INFORMATION();
            int ret = GetSystemPowerInformation(SystemPowerInformation, IntPtr.Zero, 0, out info, Marshal.SizeOf(info));
            if (ret != 0) throw new System.ComponentModel.Win32Exception(ret);
            return info.TimeRemaining;
        }
    
        public static int GetExecutionState() {
            int state = 0;
            int ret = GetSystemExecutionState(SystemExecutionState, IntPtr.Zero, 0, out state, 4);
            if (ret != 0) throw new System.ComponentModel.Win32Exception(ret);
            return state;
        }
    
        private struct SYSTEM_POWER_INFORMATION {
            public int MaxIdlenessAllowed;
            public int Idleness;
            public int TimeRemaining;
            public byte CoolingMode;
        }
        private const int SystemPowerInformation = 12;
        private const int SystemExecutionState = 16;
        [DllImport("powrprof.dll", EntryPoint = "CallNtPowerInformation", CharSet = CharSet.Auto)]
        private static extern int GetSystemPowerInformation(int level, IntPtr inpbuf, int inpbuflen, out SYSTEM_POWER_INFORMATION info, int outbuflen);
        [DllImport("powrprof.dll", EntryPoint = "CallNtPowerInformation", CharSet = CharSet.Auto)]
        private static extern int GetSystemExecutionState(int level, IntPtr inpbuf, int inpbuflen, out int state, int outbuflen);
    
    }
