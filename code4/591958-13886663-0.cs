    private void StartCapture(ICaptureDevice device)
        {
            // Register our handler function to the
            // 'packet arrival' event
            device.OnPacketArrival += new SharpPcap.PacketArrivalEventHandler(device_OnPacketArrival);
            // Open the device for capturing
            int readTimeoutMilliseconds = 1000;
            device.Open(DeviceMode.Normal, readTimeoutMilliseconds);
            device.Filter = "";
            // Start the capturing process
            device.StartCapture();
        }
    private void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            var packet = PacketDotNet.Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
            var ip = PacketDotNet.IpPacket.GetEncapsulated(packet);
            
            if (ip != null)
            {
                int destPort = 0;
                if (ip.Protocol.ToString() == "TCP")
                {
                    var tcp = PacketDotNet.TcpPacket.GetEncapsulated(packet);
                    if (tcp != null)
                    {
                        destPort = tcp.DestinationPort;
                    }
                }
                else if (ip.Protocol.ToString() == "UDP")
                {
                    var udp = PacketDotNet.UdpPacket.GetEncapsulated(packet);
                    if (udp != null)
                    {
                        destPort = udp.DestinationPort;
                    }
                }
                int dataLength = e.Packet.Data.Length;
                string sourceIp = ip.SourceAddress.ToString();
                string destIp = ip.DestinationAddress.ToString();
                string protocol = ip.Protocol.ToString();
            }
        }
