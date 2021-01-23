    public void listen()
      {
          try
          {
              packetQueue.Add(receivingUdpClient.Receive(ref RemoteIpEndPoint), RemoteIpEndPoint);
           }
          catch (Exception e)
          {
              Console.WriteLine(e.ToString());
          }
      }
