    class SmtpClientWrapper
    {
        SmtpClient _client = new SmtpClient();
        public event EventHandler BeforeSend;
        
        private void PreprocessMesage(MailMessage message)
        {
            //do something with the message topic, as you desire
        }
        public void Send(MailMessage message)
        {
            BeforeSend(this, EventArgs.Empty);
            PreprocessMessage(message);
            _client.Send(message);
        }
    }
