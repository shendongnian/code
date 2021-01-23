    public class Mail 
    {
        public delegate void MailSendComplete();
        public event MailSendComplete OnMailSendComplete;
        private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // your code 
            // finally call the complete event
            OnMailSendComplete();
        }
        public void SentEmail()
        {
            // your code 
        }
    }
