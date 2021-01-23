    // Constants from from Dbt.h
    const int WM_DEVICECHANGE = 0x219;
    const int DBT_DEVICEARRIVAL = 0x8000; 
    const uint DBT_DEVTYP_DEVICEINTERFACE = 0x05;
    const Guid GUID_DEVINTERFACE_USB_DEVICE = new Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED");
    
    
    bool PreFilterMessage(ref Message m)
    {
        if(m.Msg == case WM_DEVICECHANGE && m.WParam == DBT_DEVICEARRIVAL)
    		var broadcast = (DEV_BROADCAST_HDR)Marshal.PtrToStructure(pnt, typeof(DEV_BROADCAST_HDR));
    		if(broadcast.dbch_DeviceType == DBT_DEVTYP_DEVICEINTERFACE)
    		{
    		    var devInterface = (DEV_BROADCAST_DEVICEINTERFACE)Marshal.PtrToStructure(pnt, typeof(DEV_BROADCAST_DEVICEINTERFACE));
    			if(devInterface.dbcc_classguid = GUID_DEVINTERFACE_USB_DEVICE)
    			{
    			    // devInterface.dbcc_name will contain the VID and PID for example:
    				// \\?\USB#Vid_067b&Pid_2517#6&12115ad4&2&1#{GUID}
    			    DoSomthingSpecial(devInterface.dbcc_name);
    			}
    		}
    	}
        return false;
    }
    
    [StructLayout(LayoutKind.Sequential)]
    struct DEV_BROADCAST_HDR {
       public uint dbch_Size;
       public uint dbch_DeviceType;
       public uint dbch_Reserved;
    }
    
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct DEV_BROADCAST_DEVICEINTERFACE
    {
    		public int dbcc_size;
    		public int dbcc_devicetype;
    		public int dbcc_reserved;
    		public Guid dbcc_classguid;
    		[MarshalAs(UnmanagedType.ByValTStr, SizeConst=255)]
    		public string dbcc_name;
    }
 
