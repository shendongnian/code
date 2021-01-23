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
