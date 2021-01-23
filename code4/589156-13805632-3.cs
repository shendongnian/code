    void Main()
    {
    	IntPtr clientHandle;
    	int negotiatedVersion;
    	if(WlanOpenHandle(2, IntPtr.Zero, out negotiatedVersion, out clientHandle) != 0)
    	{
    		throw new InvalidOperationException("Could not open handle");
    	}
    	Console.WriteLine("Negotiated version:{0}", negotiatedVersion);
    	IntPtr pNetStatus = IntPtr.Zero;
    	if(WlanHostedNetworkQueryStatus(clientHandle, out pNetStatus, IntPtr.Zero) != 0)
    	{
    		throw new InvalidOperationException("Could not query network status");
    	}
    	var netStatus = (WLAN_HOSTED_NETWORK_STATUS)Marshal.PtrToStructure(pNetStatus, typeof(WLAN_HOSTED_NETWORK_STATUS));
    	Console.WriteLine(netStatus.PeerList[0]);
    	WlanFreeMemory(pNetStatus);
    	WlanCloseHandle(clientHandle, IntPtr.Zero);
    }
    
    [DllImport("Wlanapi.dll", SetLastError = true)]
    [return:MarshalAs(UnmanagedType.Bool)]
    public static extern bool WlanOpenHandle(
      [In] int dwClientVersion,
      IntPtr pReserved,
      [Out] out int pdwNegotiatedVersion,
      [Out] out IntPtr phClientHandle
    );
    [DllImport("Wlanapi.dll", SetLastError = true)]
    [return:MarshalAs(UnmanagedType.Bool)]
    public static extern bool WlanCloseHandle(
      [In] IntPtr hClientHandle,
      IntPtr pReserved
    );
    [DllImport("Wlanapi.dll", SetLastError = true)]
    static extern UInt32 WlanHostedNetworkQueryStatus(
    	[In] IntPtr hClientHandle,
    	[Out] out IntPtr ppWlanHostedNetworkStatus,
    	[In, Out] IntPtr pvReserved
    );
    	
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct _WLAN_HOSTED_NETWORK_STATUS
    {
    	public _WLAN_HOSTED_NETWORK_STATE HostedNetworkState;
    	public Guid IPDeviceID;
    	[MarshalAs(UnmanagedType.ByValTStr, SizeConst=6)]
    	public string wlanHostedNetworkBSSID;
    	public _DOT11_PHY_TYPE dot11PhyType;
    	public UInt32 ulChannelFrequency;
    	public UInt32 dwNumberOfPeers;
    	public IntPtr PeerList;
    }
    public enum _WLAN_HOSTED_NETWORK_STATE 
    { 
      wlan_hosted_network_unavailable,
      wlan_hosted_network_idle,
      wlan_hosted_network_active
    }
    public enum _DOT11_PHY_TYPE : uint
    { 
      dot11_phy_type_unknown     = 0,
      dot11_phy_type_any         = 0,
      dot11_phy_type_fhss        = 1,
      dot11_phy_type_dsss        = 2,
      dot11_phy_type_irbaseband  = 3,
      dot11_phy_type_ofdm        = 4,
      dot11_phy_type_hrdsss      = 5,
      dot11_phy_type_erp         = 6,
      dot11_phy_type_ht          = 7,
      dot11_phy_type_IHV_start   = 0x80000000,
      dot11_phy_type_IHV_end     = 0xffffffff
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct _WLAN_HOSTED_NETWORK_PEER_STATE 
    {
    	[MarshalAs(UnmanagedType.ByValTStr, SizeConst=6)]
    	public string PeerMacAddress;
    	_WLAN_HOSTED_NETWORK_PEER_AUTH_STATE PeerAuthState;
    }
    public enum _WLAN_HOSTED_NETWORK_PEER_AUTH_STATE 
    { 
      wlan_hosted_network_peer_state_invalid,
      wlan_hosted_network_peer_state_authenticated
    }
