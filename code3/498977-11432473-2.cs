    public class UserControlViewModel : ViewModelBase
    {
        //Properties
        public string UserControlMetaData { get; set; }
        public int UserControlData { get; set; }
        //Ctor
        public UserControlViewModel()
        {
            Messenger.Default.Register<NotificationMessageAction<MyDataCollection>>(this, MessageReceived);
        }
        // private Method to handle all kinds of messages.
        private void MessageReceived(MessageBase msg)
        {
            if(msg is NotificationMessageAction<MyDataCollection>)
            {
                var actionMsg = msg as NotificationMessageAction<MyDataCollection>;
                if(actionMsg.Notification == "SaveData")  // Is this the Message, we are looking for?
                {
                    // here the MainViewModels callback is called.
                    actionMsg.Execute(new MyDataCollection() {MyData = UserControlData, MyMetaData = UserControlMetaData});
                }
            }
        }
    }
