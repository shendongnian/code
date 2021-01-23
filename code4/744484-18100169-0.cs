    public class MyViewModel:ViewModelBase
    {
        public MyViewModel()
        {
            Messenger.Default.Register<NewUserNotification>(ReceiveAction);
        }
    
        private void ReceiveAction(NewUserNotification user)
        {
            ReloadMyData(user);
        }
    }
