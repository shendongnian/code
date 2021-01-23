    class SmtpClientWrapper
    {
        SmtpClient _client = new SmtpClient();
        public event EventHandler BeforeSend;
        public void Send(MailMessage message)
        {
            BeforeSend(this, null);
            //do something with the message topic, as you desire
            _client.Send(message);
        }
    }
