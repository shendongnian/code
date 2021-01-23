    public static class Unkillable
    {
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern void RtlSetProcessIsCritical(UInt32 v1, UInt32 v2, UInt32 v3);
        public static void MakeProcessUnkillable()
        {
            Process.EnterDebugMode();
            RtlSetProcessIsCritical(1, 0, 0);
        }
        public static void MakeProcessKillable()
        {
            RtlSetProcessIsCritical(0, 0, 0);
        }
    }
