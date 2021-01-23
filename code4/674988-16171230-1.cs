    enum ActionType
	{
		Forwardable, ....
	}
    class Message //could be abstract, then make classes A : Message, B: Message etc with appropriate fields
    {
		private Byte[] payload;
		
		public ActionType CurrentActionType {get;private set;}
		
		public Message(byte[] rawmessage)
		{
		    //parse message's header to determine ActionType
            //parse rest of message and save to payload or other variables in inherited classes
		}
    }
	
    Message msg = new Message((byte[])rawMessage);
    switch(msg.CurrentActionType)
    {
        case ActionType.Forwardable :
            ForwardMessage(msg); break;
        case...
        case...
    }
