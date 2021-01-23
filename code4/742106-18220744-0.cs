    string messageText;
    MQMessage msg = new MQMessage();
    while (true)
    {
        smessageText = msg.ReadString(msg.MessageLength);
        Messages.Add(messageText);
        _queue.Get(msg, mqGetNextMsgOpts);
        // Clear both MsgID and CorrelID for next use.
        msg.MessageId = MQC.MQMI_NONE;
        msg.CorrelationId = MQC.MQCI_NONE;
        // Optional, remove data from the message
        msg.ClearMessage();
    }
