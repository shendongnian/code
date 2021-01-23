    if (check.Checked == true)
    {
        foreach(string email in (List<string>hd1.Value))
        {
            System.Net.Mail.MailMessage objEmail = new System.Net.Mail.MailMessage();
            objEmail.From = new MailAddress("caio.jesus@br.com", "XXX");
            objEmail.To.Add(email);
            objEmail.Priority = System.Net.Mail.MailPriority.High;
            objEmail.IsBodyHtml = true;
            objEmail.Subject = "System NDRSecurity - Novas Requisições.";
            objEmail.Body = "TEST";
            objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
            SmtpClient objSmtp = new SmtpClient("XXX");
            objSmtp.EnableSsl = true;
            objSmtp.Port = 25;
            objSmtp.Credentials = new NetworkCredential("caio.jesus@br.com", "XXX");
            objSmtp.Send(objEmail);
        }
    }
