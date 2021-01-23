    byte[] payload = GetPayload((byte[])rawMessage);
    Type message = GetMessageType((byte[])rawMessage);
    if(IsForwardable((byte[])rawMessage))
    {
      ForwardMessage(payload);
    }
    else
    {
      TakeAppropriateAction(message, payload);
    }
