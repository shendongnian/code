	...
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct _WLAN_HOSTED_NETWORK_STATUS
	{
		public _WLAN_HOSTED_NETWORK_STATE HostedNetworkState;
		public Guid IPDeviceID;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
		public string wlanHostedNetworkBSSID;
		public _DOT11_PHY_TYPE dot11PhyType;
		public UInt32 ulChannelFrequency;
		public UInt32 dwNumberOfPeers;
		public _WLAN_HOSTED_NETWORK_PEER_STATE PeerList;
	}
	...
	IntPtr ptr = new IntPtr();
	uint hostedNetworkQueryStatusSuccess = WlanHostedNetworkQueryStatus(clientHandle, out ptr, IntPtr.Zero);
	if (openHandleSuccess == 0)
	{
		var netStat = (_WLAN_HOSTED_NETWORK_STATUS)Marshal.PtrToStructure(ptr, typeof(_WLAN_HOSTED_NETWORK_STATUS));
		Console.WriteLine(netStat.HostedNetworkState);
		if (netStat.HostedNetworkState != _WLAN_HOSTED_NETWORK_STATE.wlan_hosted_network_unavailable)
		{
			IntPtr offset = Marshal.OffsetOf(typeof(_WLAN_HOSTED_NETWORK_STATUS), "PeerList");
			for (int i = 0; i < netStat.dwNumberOfPeers; i++)
			{
				var peer = (_WLAN_HOSTED_NETWORK_PEER_STATE)Marshal.PtrToStructure(
				new IntPtr(ptr.ToInt64() + offset.ToInt64()), 
				typeof(_WLAN_HOSTED_NETWORK_PEER_STATE));
				System.Console.WriteLine(peer.PeerMacAddress);
				offset += Marshal.SizeOf(peer);
			}
		}
	}
