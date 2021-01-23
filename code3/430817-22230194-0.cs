    [StructLayout(LayoutKind.Sequential)]
    private struct SP_DEVINFO_DATA
    {
    	/// <summary>Size of the structure, in bytes.</summary>
    	public uint cbSize;
    	/// <summary>GUID of the device interface class.</summary>
    	public Guid ClassGuid;
    	/// <summary>Handle to this device instance.</summary>
    	public uint DevInst;
    	/// <summary>Reserved; do not use.</summary>
    	public IntPtr Reserved;
    }
