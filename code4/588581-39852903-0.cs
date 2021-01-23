    List<string> ids = new List<string>();
    List<AE.Net.Mail.MailMessage> mails = new List<AE.Net.Mail.MailMessage>();
    using (var imap = new AE.Net.Mail.ImapClient("imap.gmail.com", mailAccount.UserName, mailAccount.Password, AE.Net.Mail.ImapClient.AuthMethods.Login, 993, true)) 
    {
        var msgs = imap.SearchMessages(SearchCondition.Unseen());
        for (int i = 0; i < msgs.Length; i++) {
            string msgId = msgs[i].Uid;
            ids.Add(msgId);            
        }
        foreach (string id in ids)
        {
            mails.Add(imap.GetMessage(id, headersonly: false));
        }
    }
