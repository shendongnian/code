    public class Connection
    {
        //Set up an event
        public event EventHandler DataSending;
        public event EventHandler DataNotSending
        //This method will trigger the event for sending
        private void OnDataSending()
        {
            if (DataSending!= null) { DataSending(this, EventArgs.Empty); }
        }
        //this method will trigger the event for finished sending
        private void OnDataNotSending()
        {
            if (DataNotSending!= null) { DataNotSending(this, EventArgs.Empty); }
        }
        
        //This method performs your send logic
        public void Send()
        {
             //Call your method that tells the event to be raised
             OnDataSending();
             //Then put your send code
             OnDataNotSending(); //we're done!
        }
    }
