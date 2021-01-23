      public void SendUsernamePassword(string Email,string UserName,string Password)
      {
     
    
            MailMessage mM = new MailMessage();
            mM.From = new MailAddress("YourGmailAccount@gmail.com");
            mM.To.Add(Email);
            mM.Subject = "Your Username and Password.";
            mM.Body = "Your Username and Password is:<br/>Username:" + UserName+ "<br/>" + "Password:" + Password;
            mM.IsBodyHtml = true;
            mM.Priority = MailPriority.High;
            SmtpClient sC = new SmtpClient("smtp.gmail.com");
            sC.Port = 587;
            sC.Credentials = new NetworkCredential("YourGmailAccount@gmail.com", "YourPassword");
            //sC.EnableSsl = true;
            sC.EnableSsl = true;
            sC.Send(mM);
    
    
      }
