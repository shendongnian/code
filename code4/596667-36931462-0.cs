        try
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(TextFRM.Text);
            msg.To.Add(TextTO.Text);
            msg.Subject = TextSUB.Text;
            msg.Body = TextMSG.Text;
            SmtpClient sc = new SmtpClient("smtp.gmail.com");
            sc.Port = 25;
            sc.Credentials = new NetworkCredential(TextFRM.Text, TextPSD.Text);
            sc.EnableSsl = true;
            sc.Send(msg);
            Response.Write("Mail Send");
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        
        }
