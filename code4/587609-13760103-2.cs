    public bool CurrentlyConnectedToACLine
    {
        get
        {
            SYSTEM_POWER_STATUS_EX status = new SYSTEM_POWER_STATUS_EX();
            if (GetSystemPowerStatusEx(status, true))
                return status.ACLineStatus != 0;
            else
                return false;
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    internal class SYSTEM_POWER_STATUS_EX
    {
        public byte ACLineStatus = 0;
        public byte BatteryFlag = 0;
        public byte BatteryLifePercent = 0;
        public byte Reserved1 = 0;
        public uint BatteryLifeTime = 0;
        public uint BatteryFullLifeTime = 0;
        public byte Reserved2 = 0;
        public byte BackupBatteryFlag = 0;
        public byte BackupBatteryLifePercent = 0;
        public byte Reserved3 = 0;
        public uint BackupBatteryLifeTime = 0;
        public uint BackupBatteryFullLifeTime = 0;
    }
    
    [DllImport("coredll.dll")]
    private static extern bool GetSystemPowerStatusEx(SYSTEM_POWER_STATUS_EX lpSystemPowerStatus, bool fUpdate);
