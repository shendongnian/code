    IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
      Socket server = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
      try
      {
         server.Connect(ip); //Connect to the server
      } catch (SocketException e){
         Console.WriteLine("Unable to connect to server.");
         return;
      }
      Console.WriteLine("Type 'exit' to exit.");
      while(true)
      {
         string input = Console.ReadLine();
         if (input == "exit")
            break;
         server.Send(Encoding.ASCII.GetBytes(input)); //Encode from user's input, send the data
         byte[] data = new byte[1024];
         int receivedDataLength = server.Receive(data); //Wait for the data
         string stringData = Encoding.ASCII.GetString(data, 0, receivedDataLength); //Decode the data received
         Console.WriteLine(stringData); //Write the data on the screen
      }
      server.Shutdown(SocketShutdown.Both);
      server.Close();
