    try
    {
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("best@technosys.com");
        mail.To.Add("best@technosys.com");
        mail.Subject = "Accept Request";
        mail.Body = body;
        mail.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
       smtp.Credentials = new System.Net.NetworkCredential("best@technosys.com", " password");
        smtp.EnableSsl = true;
        smtp.UseDefaultCredentials = true;
        smtp.Send(mail);
    }
    catch (Exception ex)
    {
       ViewData.ModelState.AddModelError("_FORM", ex.ToString());
    }
