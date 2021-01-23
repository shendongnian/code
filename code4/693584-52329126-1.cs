    namespace RedmineMailService
    {
        
    
        // https://stackoverflow.com/questions/637866/sending-mail-without-installing-an-smtp-server
        // http://www.nullskull.com/articles/20030316.asp
        // https://www.redmine.org/boards/2/topics/26198
        // https://www.redmine.org/boards/2/topics/22259
        static class MailSender
        {
    
    
            public static void Test()
            {
                using (System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient())
                {
    
                    using (System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage())
                    {
                        client.Port = 25;
                        client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        // client.UseDefaultCredentials = true;
    
                        // Must be after UseDefaultCredentials 
                        // client.Credentials = new System.Net.NetworkCredential("mailboxname", "password", "example.com");
                        // client.Port = 587;
                        // client.EnableSsl = true;
    
                        client.Host = "COR-EXCHANGE.cor.local";
                        mail.Subject = "this is a test email.";
                        mail.Body = "Test";
    
    
                        // https://www.iana.org/assignments/message-headers/message-headers.xhtml
                        // https://tools.ietf.org/html/rfc4021#page-32
                        // mail.Headers.Add("Importance", "High"); //  High, normal, or low.
    
                        mail.Priority = System.Net.Mail.MailPriority.High;
    
                        // for read-receipt
                        mail.Headers.Add("Disposition-Notification-To", RedmineMailService.Trash.UserData.info);
    
                        string sTime = System.DateTime.UtcNow.AddDays(-1).ToString("dd MMM yyyy", System.Globalization.CultureInfo.InvariantCulture) + " " +
                            System.DateTime.UtcNow.ToShortTimeString() + " +0000"; // Fixed, from +0100 - just take UTC - works in .NET 2.0 - no need for offset
    
    
                        // Set a message expiration date
                        // When the expiration date passes, the message remains visible 
                        // in the message list with a strikethrough. 
                        // It can still be opened, but the strikethrough gives a visual clue 
                        // that the message is out of date or no longer relevant.
                        mail.Headers.Add("expiry-date", sTime);
    
    
                        // https://tools.ietf.org/html/rfc2076#page-16
                        // https://tools.ietf.org/html/rfc1911
                        // The case-insensitive values are "Personal" and "Private" 
                        // Normal, Confidential, 
    
                        // If a sensitivity header is present in the message, a conformant
                        // system MUST prohibit the recipient from forwarding this message to
                        // any other user.  If the receiving system does not support privacy and
                        // the sensitivity is one of "Personal" or "Private", the message MUST
                        // be returned to the sender with an appropriate error code indicating
                        // that privacy could not be assured and that the message was not
                        // delivered [X400].
                        mail.Headers.Add("Sensitivity", "Company-confidential");
    
                       
    
    
    
                        // for delivery receipt
                        mail.DeliveryNotificationOptions = 
                              System.Net.Mail.DeliveryNotificationOptions.OnSuccess
                            | System.Net.Mail.DeliveryNotificationOptions.OnFailure;
    
    
                        // mail.From = new System.Net.Mail.MailAddress("somebody@friends.com", "SomeBody");
                        mail.From = new System.Net.Mail.MailAddress(RedmineMailService.Trash.UserData.info, "COR ServiceDesk");
                        
    
                        mail.To.Add(new System.Net.Mail.MailAddress(RedmineMailService.Trash.UserData.Email, "A"));
                        // mail.To.Add(new System.Net.Mail.MailAddress("user1@friends.com", "B"));
                        // mail.To.Add(new System.Net.Mail.MailAddress("user2@friends.com", "B"));
                        // mail.To.Add(new System.Net.Mail.MailAddress(RedmineMailService.Trash.UserData.info, "ServiceDesk"));
    
    
                        try
                        {
                            System.Console.WriteLine("Host: " + client.Host);
                            System.Console.WriteLine("Credentials: " + System.Convert.ToString(client.Credentials));
                            client.Send(mail);
                            System.Console.WriteLine("Mail versendet");
                        }
                        catch (System.Exception ex)
                        {
                            do
                            {
                                System.Console.Write("Fehler: ");
                                System.Console.WriteLine(ex.Message);
                                System.Console.WriteLine("Stacktrace: ");
                                System.Console.WriteLine(ex.StackTrace);
                                System.Console.WriteLine(System.Environment.NewLine);
                                ex = ex.InnerException;
                            } while (ex != null);
                        } // End Catch 
    
                    } // End Using mail 
    
                } // End Using client 
    
            } // End Sub Test 
    
    
        } // End Class MailSender 
    
    
    } // End Namespace RedmineMailService.Trash 
