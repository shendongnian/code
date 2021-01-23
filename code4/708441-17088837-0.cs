    //Using the library. It resulted to be quite easy to work with the classes provided:
    
    //First I had to create a WlanClient obhect
    
    wlan = new WlanClient();
    
    //And then I can get the list of the SSIDs the PC is connected to with this code:
    
    Collection<String> connectedSsids = new Collection<string>();
    
            foreach (WlanClient.WlanInterface wlanInterface in wlan.Interfaces)
            {
                Wlan.Dot11Ssid ssid = wlanInterface.CurrentConnection.wlanAssociationAttributes.dot11Ssid;
                connectedSsids.Add(new String(Encoding.ASCII.GetChars(ssid.SSID,0, (int)ssid.SSIDLength)));
            }
