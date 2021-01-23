    class Client {
      public static void SendMovement(Movement movement) {
        Message message = Foo.Serialize(movement);
 
        socketHelper.SendMessage(message);
      }
      public static void SendPlayer(Player player) {
        // .. the same
      }
      // .. etc
      public static void OnMessageReceivedFromServer(Message message) {
        object obj = Foo.Deserialize(message);
        if (obj is Movement)
          Client.ProcessOtherPlayersMovement(obj as Movement);
        else if (obj is Player)
          Client.ProcessOtherPlayersStatusUpdates(obj as Player);
        // .. etc
         
      }
      public static void ProcessOtherPlayersMovement(Movement movement) {
        //...
      }
      // .. etc
    }
    // while on the server side
    class Server {
      public static void OnMessageReceived(Message message, SocketHelper from, SocketHelper[] all) {
        object obj = Foo.Deserialize( message );
        if (obj is Movement)
          Server.ProcessMovement( obj as Movement );
        else if (obj is Player)
          Server.ProcessPlayer( obj as Player );
        // .. etc
        
        foreach (var socketHelper in all)
          if (socketHelper != from)
            socketHelper.SendMessage( message );
      }
    }
