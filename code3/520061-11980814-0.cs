       MQMessage getMsg = new MQMessage();
       MQGetMessageOptions gmo = new MQGetMessageOptions();
       gmo.MatchOptions = MQC.MQMO_MATCH_CORREL_ID;
       
       // Copy correlationID of the message you want to receive       
       getMsg.CorrelationId = correlationId;
       
       queue.Get(getMsg, gmo);
