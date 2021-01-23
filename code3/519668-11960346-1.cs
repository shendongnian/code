    // Specify the message options
    MQPutMessageOptions pmo = new MQPutMessageOptions();
    
    // MQC.MQPMO_SYNCPOINT = provide transaction support for the Put.
    pmo.Options = MQC.MQPMO_SYNCPOINT;
    CommittableTransaction transScope = new CommittableTransaction();
    CommittableTransaction.Current = transScope;    
    
    try
    {                            
    	foreach (string agentItem in qSqlContents.Values)
    	{
    		// Define a WebSphere MQ message, writing some text in UTF format
    		MQMessage mqMessage = new MQMessage();
    		mqMessage.Write(StrToByteArray(agentItem));
    
    		// Put the message on the queue
    		_outputQueue.Put(mqMessage, pmo);
    	}                       
    }
    catch (Exception)
    {
    	transScope.Rollback();                        
    }
    finally
    {
    	_outputQueue.close();
    	transScope.Commit(); 
        transScope.Dispose();                       
    }
