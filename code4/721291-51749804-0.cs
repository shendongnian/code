     MailMessage mail = new MailMessage(); 
            mail.To.Add(txtEmail.Text.Trim()); 
            mail.To.Add("Secondry@gmail.com");
            mail.From = new MailAddress("mysendingmail@gmail.com");
            mail.Subject = "Confirmation of Registration on Job Junction.";
            string Body = "Hi, this mail is to test sending mail using Gmail in ASP.NET";
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
           // smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            smtp.Credentials = new System.Net.NetworkCredential("mysendingmail@gmail.com", "password");
           // smtp.Port = 587;
            //Or your Smtp Email ID and Password
            smtp.UseDefaultCredentials = false;
          // smtp.EnableSsl = true;
            smtp.Send(mail);
