    void ProcessIncomingMessage(CommsMessage msg)
    {
      MessageType1 msg1 = msg as MessageType1;
      if (msg1 != null)
      {
          ProcessMessageType1(msg1);
          return;
      }
      MessageType2 msg2 = msg as MessageType2;
      if (msg2 != null)
      {
          ProcessMessageType2(msg2);
          return;
      }
      //etc
    }
