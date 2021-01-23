    using System.Net.Mail;
     protected void Button1_Click(object sender, EventArgs e)
        {
          MailMessage mail = new MailMessage();
          mail.To.Add("Email ID where email is to be send");
          mail.To.Add("Another Email ID where you wanna send same email");
          mail.From = new MailAddress("YourGmailID@gmail.com");
          mail.Subject = "Email using Gmail";
        
          string Body = "Hi, this mail is to test sending mail"+ 
                        "using Gmail in ASP.NET";
          mail.Body = Body;
        
          mail.IsBodyHtml = true;
          SmtpClient smtp = new SmtpClient();
          smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
          smtp.Credentials = new System.Net.NetworkCredential
               ("YourUserName@gmail.com","YourGmailPassword");
        //Or your Smtp Email ID and Password
          smtp.EnableSsl = true;
          smtp.Send(mail);
        }
