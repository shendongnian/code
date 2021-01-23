    public class ViewModel2
    {
        public ViewModel2()
        {
            Messenger.Subscribe<VMChangedMessage>(handleMessage);
        }
        private void handleMessage(VMChangedMessage msg)
        {
            // Do something with the information here...
        }
    }
