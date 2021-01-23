    public class MessageHandler
    {
        private AutoResetEvent MessageHasSent = new AutoResetEvent(false);
        private bool IsSuccess = false;
        public void SendMessage()
        {
            MessageSender ms = new MessageSender();
            ms.MessageSent += new EventHandler<MessageSentEventArgs>(MessageHandler_MessageSent);
    
            Thread t = new Thread(ms.Send());
            t.Start();
    
            MessageHasSent.WaitOne();
            if(IsSuccess)
                //wohooo
            else
                //oh crap
    
            //Same again but for "Message recieved"
        }
        void MessageHandler_MessageSent(object sender, MessageSentEventArgs e)
        {
            IsSuccess = e.Errors.Count == 0;
            MessageHasSent.Set();
        }
    }
    public class MessageSender
    {
        public event EventHandler<MessageSentEventArgs> MessageSent;
        public void Send()
        {
            //Do some method which could potentiallialy return a List<Error>
            MessageSent(this, new MessageSentEventArgs() { Errors = new List<Error>() });
        }
    }
    public class Error { }
    public class MessageSentEventArgs : EventArgs
    {
        public List<Error> Errors;
    }
