        public void MarkAsUnread(List<string> messageIdList)
        {
            Mailbox inbox = Client.SelectMailbox("inbox");
            int[] ids = inbox.Search("ALL");
            int ListCount = messageIdList.Count;
            int MarkedAsUnread = 0;
            if (ids.Length > 0)
            {
                ActiveUp.Net.Mail.Message msg = null;
                for (var i = 0; i < ids.Length; i++)
                {
                    msg = inbox.Fetch.MessageObject(ids[i]);
                    // if messageId is on the list, mark as unread.
                    if (String.Join(",", messageIdList).Contains(msg.MessageId))
                    {                        
                        var flags = new FlagCollection { "Seen" };
                        inbox.RemoveFlagsSilent(i+1, flags);
                        MarkedAsUnread = MarkedAsUnread + 1;
                    }
                    // optimization
                    if (MarkedAsUnread == ListCount)
                    {
                        break;
                    }
                }
            }            
        }
