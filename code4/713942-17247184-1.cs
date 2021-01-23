    public static bool SendEmail(string To, string ToName, string From, string FromName, string Subject, string Body, bool IsBodyHTML)
    {
        try
        {
            MailAddress FromAddr = new MailAddress(From, FromName, System.Text.Encoding.UTF8);
            MailAddress ToAddr = new MailAddress(To, ToName, System.Text.Encoding.UTF8);
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 25,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential("your email address", "your password")
            };
            using (MailMessage message = new MailMessage(FromAddr, ToAddr)
            {
                Subject = Subject,
                Body = Body,
                IsBodyHtml = IsBodyHTML,
                BodyEncoding = System.Text.Encoding.UTF8,
            })
            {
                smtp.Send(message);
            }
            return true;
        }
        catch
        {
            return false;
        }
    }
  
