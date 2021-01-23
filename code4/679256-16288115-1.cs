    MailMessage mm = new MailMessage(@"example@hotmail.com",
                         dest, textBox1.Text, richTextBox1.Text);
    SmtpClient client = new SmtpClient("smtp.live.com", 587);
    client.Credentials = new NetworkCredential(@"examplehotmail.com", "password");
    client.EnableSsl = true;
    messageSent = false;
    client.SendAsync(mm, null);
    client.SendCompleted += SentMessageTrigger;
