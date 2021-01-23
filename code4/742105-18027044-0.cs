    while (true)
    {
    	string messageText = msg.ReadString(msg.MessageLength);
    	Messages.Add(messageText);
    	msg = new MQMessage();
    	_queue.Get(msg, mqGetNextMsgOpts);
    }
