    // http://msdn.microsoft.com/en-us/library/windows/desktop/ms681382(v=vs.85).aspx
    const int ERROR_MORE_DATA =0xEA;
    
    // http://www.pinvoke.net/default.aspx/mpr.WNetGetConnection
    [DllImport("mpr.dll", CharSet=CharSet.Auto, SetLastError=true)]
    public static extern int WNetGetConnection(
        [MarshalAs(UnmanagedType.LPTStr)] string localName, 
        [MarshalAs(UnmanagedType.LPTStr)] StringBuilder remoteName, 
        ref int length);
    
    //http://www.pinvoke.net/default.aspx/mpr.VVNetAddConnection2
    [DllImport("mpr.dll")]    
    public static extern int WNetAddConnection2(NETRESOURCE netResource,
        string password, string username, uint flags);
    
    
    [StructLayout(LayoutKind.Sequential)]
    public class NETRESOURCE
    {
         public ResourceScope Scope;
         public ResourceType ResourceType;
         public ResourceDisplaytype DisplayType;
         public int Usage;
         public string LocalName;
         public string RemoteName;
         public string Comment;
         public string Provider;
    }
    
    public enum ResourceScope : int
    {
         Connected = 1,
         GlobalNetwork,
         Remembered,
         Recent,
         Context
    }
    
    public enum ResourceType : int
    {
        Any = 0,
         Disk = 1,
         Print = 2,
         Reserved = 8,
    }
    
    public enum ResourceDisplaytype : int
    {
         Generic = 0x0,
         Domain = 0x01,
         Server = 0x02,
         Share = 0x03,
         File = 0x04,
         Group = 0x05,
         Network = 0x06,
         Root = 0x07,
         Shareadmin = 0x08,
         Directory = 0x09,
         Tree = 0x0a,
         Ndscontainer = 0x0b
    }
