        public void MarkAsUnread(string messageId)
        {
            Mailbox inbox = Client.SelectMailbox("inbox");
            int[] ids = inbox.Search("ALL");
            if (ids.Length > 0)
            {
                ActiveUp.Net.Mail.Message msg = null;
                for (var i = 0; i < ids.Length; i++)
                {
                    msg = inbox.Fetch.MessageObject(ids[i]);
                    if (msg.MessageId == messageId)
                    {                        
                        var flags = new FlagCollection { "Seen" };
                        inbox.RemoveFlagsSilent(i+1, flags);
                    }
                }
            }            
        }
