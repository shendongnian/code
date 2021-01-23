    // Expected JSON: {"toEmail":"...","fromEmail":"...","message":"..."}
    [WebMethod]
    public static bool EmailFormRequestHandler(string toEmail, string fromEmail, string message)
    {
        // TODO: Kill this code...
        // var serializer = new JavaScriptSerializer(); //stop point set here
        // serializer.RegisterConverters(new[] { new DynamicJsonConverter() });
        // dynamic obj = serializer.Deserialize(json, typeof(object));
        try
        {
            MailMessage message = new MailMessage(
                new MailAddress(toEmail),
                new MailAddress(fromEmail)
            );
            message.Subject = "email test";
            message.Body = String.Format("email test body {0}" + message);
            message.IsBodyHtml = true;
            new SmtpClient(ConfigurationManager.AppSettings["smtpServer"]).Send(message);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
