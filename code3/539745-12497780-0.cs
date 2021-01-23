    set
    {
      if(value == MessageType.Warning || value == MessageType.Info)
      {
        this.messageType = value;
      }
      else
      {
        throw new ArgumentOutOfRangeException();
      }
    }
