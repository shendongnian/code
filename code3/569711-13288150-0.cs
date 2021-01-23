       private MailMessage CreateEmailMessage(string emailAddress) {
    
            MailMessage msg = new MailMessage();
    
            msg.From = new MailAddress(FromEmailAddress, FromName);
            msg.To.Add(new MailAddress(emailAddress));
            msg.Subject = "Msg Subject here";
    
            string textBody = File.ReadAllText(TextTemplateFile);
    
    			
            string htmlBody = "";
            if (EmailFormat == "html") {
                htmlBody = File.ReadAllText(HtmlTemplateFile);
    
                foreach (Attachment inline in InlineAttachments) {
                    inline.ContentDisposition.Inline = true;
                    msg.Attachments.Add(inline);
                }
    
                AlternateView alternateHtml = AlternateView.CreateAlternateViewFromString(htmlBody,
                                                                                          new ContentType("text/html"));
                msg.AlternateViews.Add(alternateHtml);
    
                AlternateView alternateText = AlternateView.CreateAlternateViewFromString(textBody,
                                                                                          new ContentType("text/plain"));
                msg.AlternateViews.Add(alternateText);
    
            }
            else {
                msg.Body = textBody;
            }
    
            return msg;
        }
