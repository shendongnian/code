        var profile = Windows.Networking.Connectivity.NetworkInformation.GetInternetConnectionProfile();
             var interfaceType = profile.NetworkAdapter.IanaInterfaceType;
                // 71 is WiFi & 6 is Ethernet
                if (interfaceType == 71 | interfaceType == 6) 
                {
                  // Run Code
                }
                /* 3G/Mobile Detect
                else if (interfaceType == 243 | interfaceType == 244)
                {
                  // Run Code if you need to use a less quality feature.
                }*/
                else
                {
                    txtHeader.Text = "Error, Check connection or Try connecting to the Internet...";
                }
