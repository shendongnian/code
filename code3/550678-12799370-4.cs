    class SmsCenter
    {
            private DataClasses1DataContext _dbContext;
    
            public SmsCenter()
            {
                _dbContext = new DataClasses1DataContext();
            }
    
            public IEnumerable<MessageOut> GetSMSInformation()
            {
                var sms = _dbContext.MessageOuts.Where(msg => msg.msgstatus.Equals("Pending")).Select(msg => msg);
                return sms.ToList();
            }
    
    
    
            public void StartSMSSending()
            {
                var information = GetSMSInformation();
    
                foreach (var sms in information)
                {
                    SendSMS(sms.reciever, sms.msg);
                    UpdateRecords(sms,"Delivered", DateTime.Now);
                }
            }
    
            public void UpdateRecords(MessageOut sms, string msgStatus, DateTime sentTime)
            {
                sms.msgstatus = msgStatus;
                sms.senttime = sentTime;
                _dbContext.SubmitChanges();
            }
    }
