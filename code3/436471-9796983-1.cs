    private void sendMail()
    {
        string from = "myemail@email.com";
        foreach (string sendTo in emailList)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(sendTo);
            mail.From = new MailAddress(from, "Company Name'", Encoding.UTF8);
            mail.Subject = subject;
            mail.Body = msgBodyHead + msgBodyHead2 + msgDate + msgGreet + msgBody + msgAdobe + msgAssistance + msgCompliment + msgfooter;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            foreach (string sendAttachments in attachList)
            {
                mail.Attachments.Add(new Attachment(sendAttachments));
            }
    
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(from, "password");
            client.Host = "192.167.89.0";
            client.EnableSsl = false;
            try
            {
    
                progress();
                client.Send(mail);
    
            }
    
            catch (Exception ex)
            {
                ProgressBar1.Visible = false;
                timer1.Enabled = false;
                Exception excpt = ex;
                string errorMessage = string.Empty;
    
                while (excpt != null)
                {
    
                    errorMessage += excpt.ToString(); excpt = excpt.InnerException;
                    log.Error("Email - LMS Application Error", ex);
                    lblError.Text = "There was an error occured while processing your request.\n Please see Event Viewer for more details.";
                    lblError.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
