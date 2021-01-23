    var messages = new List<IMsg<IMsgId>>();
    messages.Add(new NewMsg(20));
	messages.Add(new LegacyMsg(11));
	
	foreach(var message in messages)
	{
		Console.WriteLine(message.MessageId);
	}
