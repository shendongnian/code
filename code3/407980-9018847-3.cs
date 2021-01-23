    private void ProcessData(Byte[] data, Int32 count)
    {
        using (var stream = new MemoryStream(data, 0, count))
        {
            var serializer = new XmlSerializer(typeof(ClientPacket));
    
            var packet = serializer.Deserialize(stream);
    
            // Do something with the packet
        }
    }
