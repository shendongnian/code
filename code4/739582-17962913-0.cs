    MailMessage Msg = new MailMessage();
    
    Msg.From = new MailAddress(txtUsername.Text);
       
    Msg.To.Add(txtTo.Text);
    
    Msg.Subject = txtSubject.Text;
    
    Msg.Body = txtBody.Text;
       
    SmtpClient smtp = new SmtpClient();
    
    smtp.Host = "smtp.gmail.com";
    
    smtp.Port = 587;
    
    smtp.Credentials=new System.Net.NetworkCredential(txtUsername.Text,txtpwd.Text);
    
    smtp.EnableSsl = true;
    
    smtp.Send(Msg);
