    class Client {
      public static void SendMovement(Movement movement) {
        Message message = Foo.Serialize(movement);
 
        socketHelper.SendMessage(message);
      }
      public static void SendPlayer(Player player) {
        Message message = Foo.Serialize(player);
 
        socketHelper.SendMessage(message);
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
