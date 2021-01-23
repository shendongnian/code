    public static void SendEmail(System.Net.Mail.MailMessage m)
    {
        SendEmail(m, true);
    }
    public static void SendEmail(System.Net.Mail.MailMessage m, Boolean Async)
    {
        System.Net.Mail.SmtpClient smtpClient = null;
        smtpClient = new System.Net.Mail.SmtpClient("localhost");    
        if (Async)
        {
            SendEmailDelegate sd = new SendEmailDelegate(smtpClient.Send);
            AsyncCallback cb = new AsyncCallback(SendEmailResponse);
            sd.BeginInvoke(m, cb, sd);
        }
        else
        {
            smtpClient.Send(m);
        }
    }
    private delegate void SendEmailDelegate(System.Net.Mail.MailMessage m);
    private static void SendEmailResponse(IAsyncResult ar)
    {
        SendEmailDelegate sd = (SendEmailDelegate)(ar.AsyncState);
        sd.EndInvoke(ar);
    }
