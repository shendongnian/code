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
        catch (ObjectDisposedException e)
        {
           MessageBox.Show("The email message was not sent. See the details:\n"+e.Message,
          "Error sendiing message")
         }
      }
