    ⁄⁄ Test USBm device attached
    if ( !USBm.USBm_FindDevices() )
        { 
        MessageBox.Show( string.Format("No Device Present"), "USBm Devices", MessageBoxButtons.OK, MessageBoxIcon.Information );
        return;
        }  ⁄⁄ implied else
    ⁄⁄Walk the USBm.dll functions
    ⁄⁄ some containers
    StringBuilder sb = new StringBuilder( 200 );
    bool result = false;  ⁄⁄ return values
    ⁄⁄ .DLL FindDevices  returns the number of devices
    result = USBm.USBm_FindDevices();
    ⁄⁄ return the number of devices
    int TotalDevices = USBm.USBm_NumberOfDevices();
    int Device = TotalDevices -1;  ⁄⁄ only One device is ever attached so ...
    ⁄⁄ .DLL About info
    result = USBm.USBm_About( sb );
    ⁄⁄ .DLL Version info
    result = USBm.USBm_Version( sb );
    ⁄⁄ .DLL Copyright info
    result = USBm.USBm_Copyright( sb );
    ⁄⁄ Device Valid
    result = USBm.USBm_DeviceValid( Device );
    ⁄⁄ Device Manufacturer
    result = USBm.USBm_DeviceMfr( Device, sb );
    ⁄⁄ Device Product String
    result = USBm.USBm_DeviceProd( Device, sb );
    ⁄⁄ Device Firmware Version
    int FirmVer = USBm.USBm_DeviceFirmwareVer(Device);
    ⁄⁄ Device SerialNumber [ ]
    result = USBm.USBm_DeviceSer(Device, sb);
    ⁄⁄ Device DiD
    int DID = USBm.USBm_DeviceDID(Device);
    ⁄⁄ Device PiD
    int PID = USBm.USBm_DevicePID(Device);
    ⁄⁄ Device ViD
    int VID = USBm.USBm_DeviceVID(Device);
    ⁄⁄ Device Debug String
    result = USBm.USBm_DebugString(sb);
    ⁄⁄ Device Recent Error - always returns true
    result = USBm.USBm_RecentError(sb);
    ⁄⁄ Device Clear Recent Error
    result = USBm.USBm_ClearRecentError();
    ⁄⁄ Device SetReadTimeout [ sixteen-bit millisecond value]
    uint tOUT = 3000;
    result = USBm.USBm_SetReadTimeout(tOUT);
    ⁄⁄ Device WriteDevice [ 8 byte to write (device raw commands)]
    byte[] OutBuf = { 0, 21, 3, 65, 8, 17, 60, 0 };
    result = USBm.USBm_WriteDevice(Device, OutBuf);
    ⁄⁄ Device ReadDevice [ ]
    byte[] InBuf = { 0, 0, 0, 0, 0, 0, 0, 0 };
    result = USBm.USBm_ReadDevice(Device, InBuf);
    // Device CloseDevice [ ]
    result = USBm.USBm_CloseDevice(Device);
