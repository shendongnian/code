    public bool IsWifiAvailable()
        {
         if ((NetworkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211))
             {
              return true;
             }
         else
           {
            return false;
           }
        }
        public bool threeGkAvailable()
        {
            if ((NetworkInterface.NetworkInterfaceType == NetworkInterfaceType.MobileBroadbandCdma)
                      || (NetworkInterface.NetworkInterfaceType == NetworkInterfaceType.MobileBroadbandGsm))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
