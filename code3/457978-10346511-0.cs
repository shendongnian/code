    btnSend_Click(...)
    {
       EmailSendingClass sender = new EmailSendingClass();
       //  Initialize sender with from, to, etc.
       if (!sender.IsComplete)
       {
           FrmGetMissingFields frm = new FrmGetMissingFields(sender);
       }
       sender.SendEmail();
    }
