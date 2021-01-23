    [ComImport, Guid("2246EA2D-CAEA-4444-A3C4-6DE827E44313"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAppVisibility {
        HRESULT GetAppVisibilityOnMonitor([In] IntPtr hMonitor, [Out] out MONITOR_APP_VISIBILITY pMode);
        HRESULT IsLauncherVisible([Out] out bool pfVisible);
        HRESULT Advise([In] IAppVisibilityEvents pCallback, [Out] out int pdwCookie);
        HRESULT Unadvise([In] int dwCookie);
    }
    //...
    public enum HRESULT : long {
        S_FALSE = 0x0001,
        S_OK = 0x0000,
        E_INVALIDARG = 0x80070057,
        E_OUTOFMEMORY = 0x8007000E
    }
    public enum MONITOR_APP_VISIBILITY {
        MAV_UNKNOWN = 0,         // The mode for the monitor is unknown
        MAV_NO_APP_VISIBLE = 1,
        MAV_APP_VISIBLE = 2
    }
    [ComImport, Guid("6584CE6B-7D82-49C2-89C9-C6BC02BA8C38"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAppVisibilityEvents {
        HRESULT AppVisibilityOnMonitorChanged(
            [In] IntPtr hMonitor,
            [In] MONITOR_APP_VISIBILITY previousMode,
            [In] MONITOR_APP_VISIBILITY currentMode);
    
        HRESULT LauncherVisibilityChange([In] bool currentVisibleState);
    }
