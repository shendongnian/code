    public class ViewModel : INotifyPropertyChanged
    {
        public string Message { get; set; }
        public object MyCommand { get; set; }
        public void OnMyCommand(object parameter)
        {
            Message += "I Ran something" + Environment.NewLine;
        }
        public bool CanMyCommand(object parameter)
        {
            return true;
        }
        // Injected Native Command handler
        public ViewModel(ICommandFactory factory)
        {
            MyCommand = factory.CreateInstance(OnMyCommand, CanMyCommand);
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
