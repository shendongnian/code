    public class MainViewModel : ViewModelBase 
    {
        public RelayCommand SaveCommand { get; private set; }
        //Ctor
        public MainViewModel()
        {
          SaveCommand = new RelayCommand(
                    () =>
                    Messenger.Default.Send<NotificationMessageAction<MyDataCollection>>(
                        new NotificationMessageAction<MyDataCollection>("SaveData", SaveCallback)));
        }
        private void SaveCallback(MyDataCollection dataCollection)
        {
            // process your dataCollection... 
        }
    }
