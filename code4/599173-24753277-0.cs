    using (TcpClient client = new TcpClient("127.0.0.1", 502))
    {
        ModbusSerialMaster master = ModbusSerialMaster.CreateAscii(client);
        
        // Use the master here
    }
