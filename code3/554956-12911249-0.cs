    using System.Net.Mail;
    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com",587);
    smtpClient.EnableSsl = true;
    System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("USER_NAME", "PASSWORD");
    smtpClient.Credentials = credentials;
            
    string[] tos;
    this.to=this.to.Replace(',',' ');
    //this.Bcc = this.bcc;
    tos=this.to.Split();
    for (int i = 0; i < tos.Length; i++)
    {
        MailMessage ml = new MailMessage(this.from, tos[i].ToString(), this.sub, 
                         this.msg);
        ml.IsBodyHtml = true;
        smtpClient.Send(ml);
    }
