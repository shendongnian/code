        public void UpdateRecords(MessageOut sms, string msgStatus, DateTime sentTime)
        {
            using (var db = new DataClasses1DataContext())
            {
                sms.msgstatus = msgStatus;
                sms.senttime = sentTime;
                db.SubmitChanges();
            }
        }
