    void socket_MessageReceived(DatagramSocket sender, DatagramSocketMessageReceivedEventArgs args)
    {
        using (DataReader reader = args.GetDataReader())
        {
            byte[] b = new byte[48];
    
            reader.ReadBytes(b);
    
            DateTime time = GetNetworkTime(b);
        }
    }
