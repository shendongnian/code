    var udpClient = new UdpClient();
    try
    {
        udpClient.Connect(IPAddress.Any, 162);
        UdpReceiveResult receiveAsync = await udpClient.ReceiveAsync();
        Console.WriteLine(Encoding.ASCII.GetString(receiveAsync.Buffer));
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
