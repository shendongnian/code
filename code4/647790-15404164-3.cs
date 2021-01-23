    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Messages = new ObservableCollection<Message>();
        }
        public ObservableCollection<Message> Messages { get; protected set; }
    }
