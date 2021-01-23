        using (var imap = new AE.Net.Mail.ImapClient("imap.gmail.com", mailAccount.UserName, mailAccount.Password, AE.Net.Mail.ImapClient.AuthMethods.Login, 993, true))  {
            var msgs = imap.SearchMessages(SearchCondition.Unseen());
            for (int i = 0; i < msgs.Length; i++) {
                MailMessage msg = msgs[i].Value;
		
			    foreach (var att in msg.Attachments) {
                    string fName;
				    fName = att.Filename;
                }
            }
        }
