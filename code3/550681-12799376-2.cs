    public IEnumerable<MessageOut> GetSMSInformation(DataContext context)
    {
        var sms = context.MessageOuts.Where(
            msg => msg.msgstatus.Equals("Pending")).Select(msg => msg);
        return sms.ToList();
    }
    
    public void StartSMSSending()
    {
        using (var db = new DataClasses1DataContext())
        {
            var information = GetSMSInformation(db);
    
            foreach (var sms in information)
            {
                SendSMS(sms.reciever, sms.msg);
                UpdateRecords(sms,"Delivered", DateTime.Now, db);
            }
        }
    }
    
    public void UpdateRecords(MessageOut sms, string msgStatus, DateTime sentTime, DataContext context)
    {
        sms.msgstatus = msgStatus;
        sms.senttime = sentTime;
        context.SubmitChanges();
    }
