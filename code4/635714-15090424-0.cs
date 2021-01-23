        SmtpClient client = new SmtpClient();
        MailMessage message = new MailMessage();
        message.To.Add("user_name");
        message.From = new MailAddress("user_name");
        message.Subject = "Email Confirmation";
        message.BodyEncoding = Encoding.UTF8;
        message.SubjectEncoding = Encoding.UTF8;
        client.Port = 587;
        client.Host = "smtp.live.com";
        NetworkCredential nc = new NetworkCredential("user_name", "password");
        string mail_server = "smtp.live.com";
        if (mail_server == "smtp.gmail.com" || mail_server == "smtp.live.com")
            {
                client.EnableSsl = true;
            }
            client.UseDefaultCredentials = false;
            client.Credentials = nc;
        try
        {
            client.Send(message);
        }
        catch (SmtpException exception)
        {
            Console.WriteLine(exception.Message);
        }
