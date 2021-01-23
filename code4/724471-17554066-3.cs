    private static void GetNewMailItem(_Application objOutlook, MAPIFolder objContacts, MailItem item)
    {
         if(item.ReceivedTime.Date == DateTime.Now.Date.AddDays(-1) || item.UnRead)
         {
              if (item.Attachments.Count > 0)
              {
                   var attachments = item.Attachments;
                   foreach (Attachment attachment in attachments)
                   {
                        if(attachment.Type == OlAttachmentType.olEmbeddeditem)
                        {
                             ProcessEmbeddedEmailAttachment(attachment, objOutlook, objContacts);
                        }
                        else if (attachment.FileName.EndsWith(".doc") || attachment.FileName.EndsWith(".docx"))
                        {
                             ExtractAttachment(attachment);
                             item.UnRead = false;
                        }
                   }
              }
         }
    }
