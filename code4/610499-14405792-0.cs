    var state = result.AsyncState as SocketStateObject;
    var socket = state.Socket;
    try
    {
      var numberOfBytesRead = socket.EndReceive(result);
    }
    catch(SocketException ex)
    {
      // Handle the exception here.
    }
    
    // numberOfBytesRead is not accessible out here!
    try
    {
      if(socket.Connected)
        socket.BeginReceive(...); // Receive again!
    }
    catch(SocketException ex)
    {
      // Handle the exception here too.
    }
