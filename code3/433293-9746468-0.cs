    public async void Connect()
    {
      await tcpClient.ConnectAsync(
          new Windows.Networking.HostName(Server),
          Port.ToString(),
          SocketProtectionLevel.PlainSocket);
      DataReader reader = new DataReader(tcpClient.InputStream);
      reader.InputStreamOptions = InputStreamOptions.Partial;
      while (true)
      {
        var bytesAvailable = await reader.LoadAsync(1000);
        var byteArray = new byte[bytesAvailable];
        reader.ReadBytes(byteArray);
        // unsafe 
        //{
        //   fixed(Byte *fixedByteBuffer = &byteArray[0])
        //  {
        vCtrl.Consume(byteArray);
        vCtrl.Decode();
        // }
        //}
      }
    }
