    var devManager = Activator.CreateInstance(typeof(CLSID_PortableDeviceManager)) as IPortableDeviceManager;
    uint pcPnPDeviceIDs = 0;
    HRESULT res1 = devManager.GetDevices(null, ref pcPnPDeviceIDs);
    // check for errors in res1
    IntPtr[] ptr = null;
    try
    {
        ptr = new IntPtr[pcPnPDeviceIDs];
        HRESULT res2 = devManager.GetDevices(ptr, ref pcPnPDeviceIDs);
        // check for errors in res2
        for (uint i = 0; i < pcPnPDeviceIDs; i++)
        {
            string str = Marshal.PtrToStringUni(ptr[i]);
        }
    }
    finally
    {
        if (ptr != null)
        {
            for (uint i = 0; i < pcPnPDeviceIDs; i++)
            {
                Marshal.FreeCoTaskMem(ptr[i]);
            }
        }
    }
