    enum MessageType
    { 
       None = 0,
       Msg1,
       Msg2
    }
     
    public static string GetNewType(MessageType MType)
    {
        string msg = string.Empty;
        switch (MType)
        {
          case MessageType.Msg1:
             msg = MSG_1;
             break;
          case MessageType.Msg2:
             msg = MSG_2;
             break;
        }
        return msg;
    }
