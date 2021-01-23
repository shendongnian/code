    public class EmailSender
    {
        private System.Timers.Timer _timer = new Timer(1000);
    
        public EmailSender()
        {
            _timer.Elapsed += (object sender, ElapsedEventArgs args) => SendEmail();
        }
        
        public void StartSender()
        {
            _timer.Enabled = true;
        }
    
        public void SendEmail()
        {
            // you *may* want to stop your timer here in case the send of the ten overruns 1s.
            _timer.Enabled = false;
    
            // code here to send UP TO ten emails
    
            // re-enable timer, if you stopped it above.
            _timer.Enabled = true;
        }
    }
