    /// <summary>
    /// Find WIFI SSID
    /// </summary>
    private void FindWIFISSIDClick(object sender, RoutedEventArgs e)
    {
        foreach (var network in new NetworkInterfaceList())
        {
            if ( (network.InterfaceType == NetworkInterfaceType.Wireless80211) &&  (network.InterfaceState == ConnectState.Connected) )
                mLocatoinInfo.Text = network.InterfaceName; //Get the SSID of the WIFI
            else
                mLocatoinInfo.Text = "fail";
        }
    }
