      /*your SendCompleted EventHandler*/
     if (e.Canceled)
      {
        //if you use using(message) {...} here, you'll get ObjectDisposedException again
       SmtpClient smtp;
        smtp = new SmtpClient();  
         smtp = GetClient(smtp);  //method of your smtpClient initialization
        MailMessage mess = new MailMessage();
        mess = GetMessage(mess, smtp);  //method of your mailMessage initialization
        try
        {
            //sending message again
            smtp.SendAsync(mess, null);
        }
        catch (ObjectDisposedException)
        {
           SmtpClient s = new SmtpClient();
           s = GetClient(s); //new instance of smtpClient initialization
           MailMessage m = new MailMessage();
           m = GetMessage(m, s);
           s.SendAsync(m, null);
         }
      }
