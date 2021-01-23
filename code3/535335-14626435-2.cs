    packet.Type = ICMP_ECHO;  --> ICMP_ECHO must be set with a number (8) manual
    {
        private static int Serialize(IcmpPacket packet, byte[] buffer, int packetSize, int pingData)
                {
                    // (Private method for serializing the packet omitted.)
                }
                private static UInt16 CheckSum(UInt16[] buffer, int size)
                {
                    // (Private method for calculating the checksum omitted.)
            }
    }
    <--mustbe create by your own 
        private static void Main()
            {
               int GetPingMS(string hostNameOrAddress);
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            return Convert.ToInt32(ping.SendAddress.RoundtripTime);
        // How to call this function (IP Address).
        MessageBox.Show ( GetPingMs("122.198.1.1"));
            }
