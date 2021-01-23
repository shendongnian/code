    public async static Task<IEnumerable<HueBridge>> DiscoverAsync(TimeSpan timeout)
    {
      if (timeout <= TimeSpan.Zero)
        throw new ArgumentException("Timeout value must be greater than zero.", "timeout");
      var discoveredBridges = new List<HueBridge>();
      var multicastIP = new HostName("239.255.255.250");
      var bridgeWasFound = false;
      using (var socket = new DatagramSocket())
      {
        socket.MessageReceived += (sender, e) =>
        {
          var reader = e.GetDataReader();
          var bytesRemaining = reader.UnconsumedBufferLength;
          var receivedString = reader.ReadString(bytesRemaining);
          // TODO: Check for existing bridges, only add new ones to prevent infinite loop.
          // TODO: Create new bridge and add to the list. 
          bridgeWasFound = true;
        };
        await socket.BindEndpointAsync(null, string.Empty);
        socket.JoinMulticastGroup(multicastIP);
        while (true)
        {
          bridgeWasFound = false;
          using (var stream = await socket.GetOutputStreamAsync(multicastIP, "1900"))
          using (var writer = new DataWriter(stream))
          {
            var request = new StringBuilder();
            request.AppendLine("M-SEARCH * HTTP/1.1");
            request.AppendLine("HOST: 239.255.255.250:1900");
            request.AppendLine("MAN: ssdp:discover");
            request.AppendLine("MX: 3");
            request.AppendLine("ST: ssdp:all");
            writer.WriteString(request.ToString());
            await writer.StoreAsync();
            if (timeout > TimeSpan.Zero)
              await Task.Delay(timeout);
            if (!bridgeWasFound)
              break;
          }
        }
      }
      return discoveredBridges;
    }
