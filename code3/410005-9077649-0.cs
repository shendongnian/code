      Socket client1 = serverSocket.Accept(); // blocks until one connects
      Socket client2 = serverSocket.Accept(); // same here
    
      var buffer = Encoding.ASCII.GetBytes("HEllo world!");
      client1.Send(buffer, 0, buffer.Count); //sending to client 1
      client2.Send(buffer, 0, buffer.Count); //sending to client 2
