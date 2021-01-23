    public class EmailSender
    {
        ConcurrentQueue<MailMessage> _queue = new ConcurrentQueue<MailMessage>();
        private Thread _worker;
        ManualResetEvent _trigger = new ManualResetEvent(false);
        private bool _shutdown;
        public EmailSender()
        {
            _worker = new Thread(SendEmails);
            _worker.Start();
        }
        public void Enqueue(MailMessage message)
        {
            _queue.Enqueue(message);
            _trigger.Set();
        }
        public void Shutdown()
        {
            _shutdown = true;
            _trigger.Set();
            _worker.Join();
        }
        private void SendEmails(object state)
        {
            while (true)
            {
                _trigger.WaitOne(Timeout.Infinite);
                if (_shutdown)
                    return; // you might want to send all emails instead.
                MailMessage msg;
                if (!_queue.TryDequeue(out msg))
                {
                    _trigger.Reset();
                    continue;
                }
                SendEmail(msg);
            }
        }
        private void SendEmail(MailMessage msg)
        {
            var client = new SmtpClient(); // configure
            try
            {
                client.Send(msg);
            }
            catch(SmtpException)
            {
                // try again. You might not want to retry forever = fix
                _queue.Enqueue(msg);
            }
        }
    }
