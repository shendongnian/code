    public void SendEmail(string from, string to, string subject, string body)
    {
        string host = "smtp.gmail.com";
        int port = 587;
        MailMessage msg = new MailMessage(from, to, subject, body);
        SmtpClient smtp = new SmtpClient(host, port);
    
        string username = "example@gmail.com";
        string password = "1234567890";
    
        smtp.Credentials = new NetworkCredential(username, password);
        smtp.EnableSsl = true;
        smtp.UseDefaultCredentials = false;
    
        try
        {    
            smtp.Send(msg);
        }
        catch (Exception exp)
        {
            //Log if any errors occur
        }
    }
