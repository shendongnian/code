    internal bool SendPacket(Packet p)
    {
      bool sentOk = false;
      BinaryFormatter bin = new BinaryFormatter();
      try
      {
        bin.write (p.MessageItem.GetType ().Name); // or whatever the write/serialise function is called
        bin.Serialize(theNetworkStream, p);
      }
      catch etc..
    }
