      public void ContinuousReceive(){
        byte[] buffer = new byte[1024];
        bool terminationCodeReceived = false;
        while(!terminationCodeReceived){
          try{
              if(server.Receive(buffer)>0){
                 // We got something
                 // Parse the received data and check if the termination code
                 // is received or not
              }
          }catch (SocketException e){
              Console.WriteLine("Oops! Something bad happened:" + e.Message);
          }
        }
      }
