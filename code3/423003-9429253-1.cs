    public Boolean isConnected()
    {
        NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
        foreach (NetworkInterface face in interfaces)
        {
            if (face.OperationalStatus == OperationalStatus.Up || face.OperationalStatus == OperationalStatus.Unknown)
            {
                // Internal network interfaces from VM adapters can still be connected 
                IPv4InterfaceStatistics statistics = face.GetIPv4Statistics();
                if (statistics.BytesReceived > 0 && statistics.BytesSent > 0)
                {
                    // A network interface is up
                    return true;
                }
            }
        }
        // No Interfaces are up
        return false;
    }
