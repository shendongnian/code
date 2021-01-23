    _queueManager = new MQQueueManager(Queuemanager, _mqProperties);
       
    MQQueue queue = _queueManager.AccessQueue(
        Queuename, 
        MQC.MQOO_INPUT_AS_Q_DEF + MQC.MQOO_FAIL_IF_QUIESCING + MQC.MQOO_INQUIRE);            
    string xml = "";
    while (queue.CurrentDepth > 0)
    {
        MQMessage message = new MQMessage();                
        queue.Get(message);
        xml = message.ReadString(message.MessageLength);
        MsgQueue.Enqueue(xml);                    
        message.ClearMessage();                                
    }
