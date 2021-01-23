    public IEnumerable<MessageOut> GetSMSInformation()
    {
        var sms = Context.MessageOuts.Where(
            msg => msg.msgstatus.Equals("Pending")).Select(msg => msg);
        return sms.ToList();
    }
    
    public void StartSMSSending()
    {
        var information = GetSMSInformation(db);
    
        foreach (var sms in information)
        {
            SendSMS(sms.reciever, sms.msg);
            UpdateRecords(sms,"Delivered", DateTime.Now, db);
        }
    }
    
    public void UpdateRecords(MessageOut sms, string msgStatus, DateTime sentTime)
    {
        sms.msgstatus = msgStatus;
        sms.senttime = sentTime;
        Context.SubmitChanges();
    }
    private DataClasses1DataContext _context = null;
    public DataClasses1DataContextContext
    {
        get
        {
            if (_comtext == null)
                _context = new DataClasses1DataContext();
            return _context;
        }
    }
