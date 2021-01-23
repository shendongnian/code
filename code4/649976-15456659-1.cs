    public class Connection
    {
        //Set up an event
        public event EventHandler DataSent;
        //This method will trigger the event
        public void OnDataSent()
        {
            if (DataSent != null) { DataSent(this, EventArgs.Empty); }
        }
        
        //This method performs your send logic
        public void Send()
        {
             //Call your method that tells the event to be raised
             OnDataSent();
             //Then put your send code
        }
    }
