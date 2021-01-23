        /// <summary>
        /// Gets/Sets the IPAddress(s) of the computer which the client is running on.
        /// If this isn't set then all IPAddresses which could be enumerated will be sent as
        /// a comma separated list.  
        /// </summary>
        public string IPAddress
        {
            set
            {
                _IPAddress = value;
            }
            get
            {
                string retVal = _IPAddress;
                // If IPAddress isn't explicitly set then we enumerate all IP's on this machine.
                if (_IPAddress == null)
                {
                    // TODO: Only return ipaddresses that are for Ethernet Adapters
                    String strHostName = Dns.GetHostName();
                    IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
                    IPAddress[] addr = ipEntry.AddressList;
                  
                    List<string> validAddresses = new List<string>();
                    // Loops through the addresses and creates a list of valid ones.
                    for (int i = 0; i < addr.Length; i++)
                    {
                        string currAddr = addr[i].ToString();
                        if( IsValidIP( currAddr ) ) {
                            validAddresses.Add( currAddr );
                        }
                    }
                    for(int i=0; i<validAddresses.Count; i++)
                    {
                        retVal += validAddresses[i];
                        if (i < validAddresses.Count - 1)
                        {
                            retVal += ",";
                        }
                    }
                    if (String.IsNullOrEmpty(retVal))
                    {
                        retVal = String.Empty;
                    }
                }
                return retVal;
            }
        }
