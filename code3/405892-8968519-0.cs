    ImageStream = new MemoryStream();
    while (AccumulatingBytes <= TotalSizeOfComplexObject)
    {
        byte[] Recievedbytes = UdpListener.Receive(ref RemoteEndPoint);
        ImageStream.Write(Recievedbytes, 0, Recievedbytes.Length);
        AccumulatingBytes += Recievedbytes.Length;
    } 
