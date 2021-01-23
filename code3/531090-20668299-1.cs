    /// <summary>
    /// Retrieves information about the raw input device.
    /// </summary>
    /// <param name="hDevice">A handle to the raw input device. This comes from the lParam of the WM_INPUT message, from the hDevice member of RAWINPUTHEADER, or from GetRawInputDeviceList. It can also be NULL if an application inserts input data, for example, by using SendInput.</param>
    /// <param name="uiCommand">Specifies what data will be returned in pData.</param>
    /// <param name="pData">A pointer to a buffer that contains the information specified by uiCommand. If uiCommand is RIDI_DEVICEINFO, set the cbSize member of RID_DEVICE_INFO to sizeof(RID_DEVICE_INFO) before calling GetRawInputDeviceInfo. </param>
    /// <param name="pcbSize">The size, in bytes, of the data in pData. </param>
    /// <returns>If successful, this function returns a non-negative number indicating the number of bytes copied to pData. If pData is not large enough for the data, the function returns -1. If pData is NULL, the function returns a value of zero. In both of these cases, pcbSize is set to the minimum size required for the pData buffer. Call GetLastError to identify any other errors.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/windows/desktop/ms645597%28v=vs.85%29.aspx</remarks>
    [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern uint GetRawInputDeviceInfo(
        [In] IntPtr hDevice,
        [In] RawInputDeviceInformationCommand uiCommand,
        [In, Out] IntPtr pData,
        [In, Out] ref uint pcbSize);
        
    public enum RawInputDeviceInformationCommand : int
    {
        /// <summary>
        /// pData points to a string that contains the device name. For this uiCommand only, the value in pcbSize is the character count (not the byte count).
        /// </summary>
        RIDI_DEVICENAME = 0x20000007,
        /// <summary>
        /// pData points to an RID_DEVICE_INFO structure.
        /// </summary>
        RIDI_DEVICEINFO = 0x2000000b,
        /// <summary>
        /// pData points to the previously parsed data.
        /// </summary>
        RIDI_PREPARSEDDATA = 0x20000005
    }
    
    [StructLayout(LayoutKind.Explicit)]
    public struct RID_DEVICE_INFO
    {
        /// <summary>
        /// The size, in bytes, of the RID_DEVICE_INFO structure. 
        /// </summary>
        [FieldOffset(0)]
        public int cbSize;
        /// <summary>
        /// The type of raw input data.
        /// </summary>
        [FieldOffset(4)]
        public RawInputDeviceType dwType;
        /// <summary>
        /// If dwType is RIM_TYPEMOUSE, this is the RID_DEVICE_INFO_MOUSE structure that defines the mouse. 
        /// </summary>
        [FieldOffset(8)]
        public RID_DEVICE_INFO_MOUSE mouse;
        /// <summary>
        /// If dwType is RIM_TYPEKEYBOARD, this is the RID_DEVICE_INFO_KEYBOARD structure that defines the keyboard. 
        /// </summary>
        [FieldOffset(8)]
        public RID_DEVICE_INFO_KEYBOARD keyboard;
        /// <summary>
        /// If dwType is RIM_TYPEHID, this is the RID_DEVICE_INFO_HID structure that defines the HID device. 
        /// </summary>
        [FieldOffset(8)]
        public RID_DEVICE_INFO_HID hid;
    }
    /// <summary>
    /// Defines the raw input data coming from the specified mouse.
    /// </summary>
    /// <remarks>http://msdn.microsoft.com/en-us/library/windows/desktop/ms645589%28v=vs.85%29.aspx</remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct RID_DEVICE_INFO_MOUSE
    {
        /// <summary>
        /// The identifier of the mouse device.
        /// </summary>
        public int dwId;
        /// <summary>
        /// The number of buttons for the mouse.
        /// </summary>
        public int dwNumberOfButtons;
        /// <summary>
        /// The number of data points per second. This information may not be applicable for every mouse device.
        /// </summary>
        public int dwSampleRate;
        /// <summary>
        /// TRUE if the mouse has a wheel for horizontal scrolling; otherwise, FALSE.
        /// Windows XP:  This member is only supported starting with Windows Vista.
        /// </summary>
        public bool fHasHorizontalWheel;
    }
    /// <summary>
    /// Defines the raw input data coming from the specified keyboard. 
    /// </summary>
    /// <remarks>http://msdn.microsoft.com/en-us/library/windows/desktop/ms645587%28v=vs.85%29.aspx</remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct RID_DEVICE_INFO_KEYBOARD
    {
        /// <summary>
        /// The type of the keyboard. 
        /// </summary>
        public int dwType;
        /// <summary>
        /// The subtype of the keyboard. 
        /// </summary>
        public int dwSubType;
        /// <summary>
        /// The scan code mode. 
        /// </summary>
        public int dwKeyboardMode;
        /// <summary>
        /// The number of function keys on the keyboard.
        /// </summary>
        public int dwNumberOfFunctionKeys;
        /// <summary>
        /// The number of LED indicators on the keyboard.
        /// </summary>
        public int dwNumberOfIndicators;
        /// <summary>
        /// The total number of keys on the keyboard. 
        /// </summary>
        public int dwNumberOfKeysTotal;
    }
    /// <summary>
    /// Defines the raw input data coming from the specified Human Interface Device (HID). 
    /// </summary>
    /// <remarks>http://msdn.microsoft.com/en-us/library/windows/desktop/ms645584%28v=vs.85%29.aspx</remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct RID_DEVICE_INFO_HID
    {
        /// <summary>
        /// The vendor identifier for the HID. 
        /// </summary>
        public int dwVendorId;
        /// <summary>
        /// The product identifier for the HID. 
        /// </summary>
        public int dwProductId;
        /// <summary>
        /// The version number for the HID. 
        /// </summary>
        public int dwVersionNumber;
        /// <summary>
        /// The top-level collection Usage Page for the device. 
        /// </summary>
        public ushort usUsagePage;
        /// <summary>
        /// The top-level collection Usage for the device. 
        /// </summary>
        public ushort usUsage;
    }
    /// <summary>
    /// The type of raw input data.
    /// </summary>
    public enum RawInputDeviceType : int
    {
        /// <summary>
        /// Data comes from a mouse.
        /// </summary>
        RIM_TYPEMOUSE = 0,
        /// <summary>
        /// Data comes from a keyboard.
        /// </summary>
        RIM_TYPEKEYBOARD = 1,
        /// <summary>
        /// Data comes from an HID that is not a keyboard or a mouse.
        /// </summary>
        RIM_TYPEHID = 2,
    }
    //somewhere in your code:
    IntPtr pData = IntPtr.Zero;
    uint strsize = 0;
    IntPtr deviceHandle = <your device handle here>;
    result = GetRawInputDeviceInfo(deviceHandle, RawInputDeviceInformationCommand.RIDI_DEVICENAME, pData, ref strsize);
    pData = Marshal.AllocHGlobal(((int)strsize)*2);
    result = GetRawInputDeviceInfo(deviceHandle, RawInputDeviceInformationCommand.RIDI_DEVICENAME, pData, ref strsize);
    Console.WriteLine("Result = " + result + " ErrorCode = " + Marshal.GetLastWin32Error());
    string name = Marshal.PtrToStringAuto(pData);
    Console.WriteLine("Name = " + name);
    uint structsize = (uint)Marshal.SizeOf(typeof(RID_DEVICE_INFO));
    RID_DEVICE_INFO di = new RID_DEVICE_INFO();
    di.cbSize = (int)structsize;
    pData = Marshal.AllocHGlobal((int)structsize);
    result = GetRawInputDeviceInfo(deviceHandle, RawInputDeviceInformationCommand.RIDI_DEVICEINFO, pData, ref structsize);
    di = (RID_DEVICE_INFO)Marshal.PtrToStructure(pData, typeof(RID_DEVICE_INFO));
    Console.WriteLine("di.dwType = " + Enum.GetName(typeof(RawInputDeviceType), di.dwType));
    switch (di.dwType)
    {
        case RawInputDeviceType.RIM_TYPEHID:
            Console.WriteLine("di.hid.dwVendorId = " + di.hid.dwVendorId);
            Console.WriteLine("di.hid.dwProductId = " + di.hid.dwProductId);
            Console.WriteLine("di.hid.dwVersionNumber = " + di.hid.dwVersionNumber);
            Console.WriteLine("di.hid.usUsagePage = " + di.hid.usUsagePage);
            Console.WriteLine("di.hid.usUsage = " + di.hid.usUsage);
            break;
        case RawInputDeviceType.RIM_TYPEKEYBOARD:
            Console.WriteLine("di.keyboard.dwType = " + di.keyboard.dwType);
            Console.WriteLine("di.keyboard.dwSubType = " + di.keyboard.dwSubType);
            Console.WriteLine("di.keyboard.dwNumberOfFunctionKeys = " + di.keyboard.dwNumberOfFunctionKeys);
            Console.WriteLine("di.keyboard.dwNumberOfIndicators = " + di.keyboard.dwNumberOfIndicators);
            Console.WriteLine("di.keyboard.dwNumberOfKeysTotal = " + di.keyboard.dwNumberOfKeysTotal);
            break;
        case RawInputDeviceType.RIM_TYPEMOUSE:
            Console.WriteLine("di.mouse.dwId = " + di.mouse.dwId);
            Console.WriteLine("di.mouse.dwNumberOfButtons = " + di.mouse.dwNumberOfButtons);
            Console.WriteLine("di.mouse.dwSampleRate = " + di.mouse.dwSampleRate);
            Console.WriteLine("di.mouse.fHasHorizontalWheel = " + di.mouse.fHasHorizontalWheel);
            break;
        default:
            break;
    }
