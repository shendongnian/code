    private void BtnSendEmailClick(object sender, RoutedEventArgs e)
    {
        // Display progress image
        progressImage.Visible = true;
        string errorMessage = await SendEmail();
 
        if (errorMessage == null) 
        {
            lblMessage.Content = "Successfully sent to your Mail!";
        }
        else
        {
            lblMessage.Content = errorMessage;
        }
        
        progressImage.Visible = false;
    }
    private async Task<string> SendEmail()
    {
        try
        {
            var msg = new MailMessage
            {
                From = new MailAddress("me@hotmail.com", "Me Hotmail")
            };
            msg.To.Add(txtEmailAddress.Text);
            msg.Priority = MailPriority.High;
            msg.Subject = "Blah blah";
            msg.Body =
                "<!DOCTYPE html><html lang='en' xmlns='http://www.w3.org/1999/xhtml'>" +
                "<head> </head>" +
                "<body>" +
                "<h3>Message</h3>" +
                "<p>" + lblEmailMessage.Content + "</p>" +
                "</body>" +
                "</html>";
            msg.IsBodyHtml = true;
            var client = new SmtpClient
            {
                Host = "smtp.live.com",
                Port = 25,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("me@hotmail.com", "password"),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            //how to implement while loop for processing
            client.Send(msg);
            return "Successfully sent to your Mail!";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
