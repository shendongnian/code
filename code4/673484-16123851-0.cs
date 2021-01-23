    [DllImport("User32.dll")]
    private static extern StatusCode DisplayConfigSetDeviceInfo(IntPtr requestPacket);
    public static StatusCode DisplayConfigSetDeviceInfo<T>(ref T displayConfig) 
       where T : IDisplayConfigInfo
    {
        return WrapStructureAndCall(ref displayConfig, DisplayConfigSetDeviceInfo);
    }
	
    [DllImport("User32.dll")]
    private static extern StatusCode DisplayConfigGetDeviceInfo(IntPtr targetDeviceName);
    public static StatusCode DisplayConfigGetDeviceInfo<T>(ref T displayConfig) 
      where T : IDisplayConfigInfo
    {
        return WrapStructureAndCall(ref displayConfig, DisplayConfigGetDeviceInfo);
    }
    public static StatusCode WrapStructureAndCall<T>(ref T displayConfig,
        Func<IntPtr, StatusCode> func) where T : IDisplayConfigInfo
    {
        var ptr = Marshal.AllocHGlobal(Marshal.SizeOf(displayConfig));
        Marshal.StructureToPtr(displayConfig, ptr, false);
        var retval = func(ptr);
        displayConfig = (T)Marshal.PtrToStructure(ptr, displayConfig.GetType());
        Marshal.FreeHGlobal(ptr);
        return retval;
    }
