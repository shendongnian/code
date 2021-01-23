        	for (int i = 0; i < items.Count; i++)
			{
				var mailItem = items[i] as Outlook.MailItem;
				if (mailItem != null)
				{
					SenderName = mailItem.SenderName;
					//etc...
				}
			}
        
