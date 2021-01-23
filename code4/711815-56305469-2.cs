    List<string> messagesList = new List<messageList>();
    List<SmsPdu> multiPartMsg = new List<SmsPdu>();
   
    foreach (var i in modem.ReadMessages(PhoneMessageStatus.All, PhoneStorageType.Phone))
    {
        string msg;
        
        if (SmartMessageDecoder.IsPartOfConcatMessage(((SmsDeliverPdu)i.Data)))
        {
            multiPartMsg.Add(i.Data);
            try
            {
                if (SmartMessageDecoder.AreAllConcatPartsPresent(multiPartMsg))
                {
                    msg= SmartMessageDecoder.CombineConcatMessageText(multiPartMsg);
                    messagesList.Add(msg);
                    multiPartMsg.Clear();
                    
                }
            }
            catch (Exception ex) {}
        }
        else
        {
            msg = ((SmsDeliverPdu)i.Data).UserDataText;
            messagesList.Add(msg);
        }
    }
                        
                       
