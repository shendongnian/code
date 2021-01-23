    [DllImport("setupapi.dll")]
        public static extern bool SetupCopyOEMInf(
            string SourceInfFileName,
            string OEMSourceMediaLocation,
            int OEMSourceMediaType,
            int CopyStyle,
            string DestinationInfFileName,
            int DestinationInfFileNameSize,
            int RequiredSize,
            string DestinationInfFileNameComponent
            );
    
        [DllImport("newdev.dll")]
        public static extern bool UpdateDriverForPlugAndPlayDevices(
            IntPtr hwndParent,
            string HardwareId,
            string FullInfPath,
            uint InstallFlags,
            bool bRebootRequired
            );
    
        [STAThread]
        static void Main() {
          if (SetupCopyOEMInf(infPath, null, 0, 0, null, 0, 0, null)) {
            foreach (string device in devices) {
              UpdateDriverForPlugAndPlayDevices(IntPtr.Zero, device, infPath, 0, false);
            }
          }
        }
