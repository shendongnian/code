    public static string SendMailMessage(MailMessage message)
    {
        if (message == null)
        {
            throw new ArgumentNullException("message");
        }
    
        StringBuilder errorMsg = new StringBuilder();
    
        try
        {
            message.IsBodyHtml = true;
            message.BodyEncoding = Encoding.UTF8;
            var smtp = new SmtpClient(Settings.Instance.SmtpServer);
    
            // don't send credentials if a server doesn't require it,
            // linux smtp servers don't like that 
            if (!string.IsNullOrEmpty(Settings.Instance.SmtpUserName))
            {
                smtp.Credentials = new NetworkCredential(yourusername, yourpassword));
            }
    
            smtp.Port = Settings.Instance.SmtpServerPort;
            smtp.EnableSsl = Settings.Instance.EnableSsl;
            smtp.Send(message);
        }
        catch (Exception ex)
        {
            errorMsg.Append("Error sending email in SendMailMessage: ");
            Exception current = ex;
    
            while (current != null)
            {
                if (errorMsg.Length > 0) { errorMsg.Append(" "); }
                errorMsg.Append(current.Message);
                current = current.InnerException;
    
                Logger.Error("Error sending email in SendMailMessage.", ex);
            }
        }
        finally
        {
            // Remove the pointer to the message object so the GC can close the thread.
            message.Dispose();
        }
    
        return errorMsg.ToString();
    }
    
    public static void SendMailMessageAsync(MailMessage message)
    {
        ThreadPool.QueueUserWorkItem(delegate { SendMailMessage(message); });
    }
