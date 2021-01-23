    public void openAdapterForStatistics(object param)
    {
        PacketDevice selectedOutputDevice = (PacketDevice)param;
        using (PacketCommunicator statCommunicator = selectedOutputDevice.Open(100, PacketDeviceOpenAttributes.Promiscuous, 1000)) //open the output adapter
        {
            statCommunicator.Mode = PacketCommunicatorMode.Statistics; //put the interface in statstics mode                
            statCommunicator.ReceiveStatistics(0, statisticsHandler);
    
        }
    }
