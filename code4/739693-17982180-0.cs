            string host = "email-smtp.us-east-1.amazonaws.com";
            int port = 25;
            var credentials = new NetworkCredential("ses-smtp-username", "ses-smtp-password");
            var sender = new MailAddress("sender@example.com", "Message Sender");
            var recipientTo = new MailAddress("recipient+one@example.com", "Recipient One");
            var subject = "HTML and TXT views";
            var htmlView = AlternateView.CreateAlternateViewFromString("<p>This message is <code>formatted</code> with <strong>HTML</strong>.</p>", Encoding.UTF8, MediaTypeNames.Text.Html);
            var txtView = AlternateView.CreateAlternateViewFromString("This is a plain text message.", Encoding.UTF8, MediaTypeNames.Text.Plain);
            var message = new MailMessage();
            message.Subject = subject;
            message.From = sender;
            message.To.Add(recipientTo);
            message.AlternateViews.Add(txtView);
            message.AlternateViews.Add(htmlView);
            using (var client = new SmtpClient(host, port))
            {
                client.Credentials = credentials;
                client.EnableSsl = true;
                client.Send(message);
            }
