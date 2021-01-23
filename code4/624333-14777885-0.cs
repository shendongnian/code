    MailMessage mail = new MailMessage();
            mail.To.Add(textBox1.Text);
            
            mail.From = new MailAddress("Yourgmailid");
            mail.Subject = "Email using Gmail";
 
            string Body = "Hi, this mail is to test sending mail" +
                          "using Gmail in ASP.NET";
            mail.Body = Body;
 
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; 
            smtp.Credentials = new System.Net.NetworkCredential
                 ("Yourgmailid, "Password");
            
            smtp.EnableSsl = true;
            smtp.Send(mail);
