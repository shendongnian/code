    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public ICommand RemoveHistoryItemCommand { get; private set; }
        private HistoryItem _selectedHistoryItem;
        public HistoryItem SelectedHistoryItem { get { return _selectedHistoryItem; } set { _selectedHistoryItem = value; OnPropertyChanged("SelectedHistoryItem"); } }
        private ObservableCollection<HistoryItem> _historyItems = new ObservableCollection<HistoryItem>();
        public ObservableCollection<HistoryItem> HistoryItems { get { return _historyItems; } set { _historyItems = value; OnPropertyChanged("HistoryItems"); } }
        public ViewModel()
        {
            this.RemoveHistoryItemCommand = new ActionCommand(RemoveHistoryItem);
            this.HistoryItems.Add(new HistoryItem() { Year = "1618", Description = "Start of war" });
            this.HistoryItems.Add(new HistoryItem() { Year = "1648", Description = "End of war" });
        }
        // command handler
        private void RemoveHistoryItem()
        {            
            if (this.HistoryItems != null)
            {
                HistoryItems.Remove(this.SelectedHistoryItem);
            }
        }
    }
    public class HistoryItem
    {
        public string Year { get; set; }
        public string Description { get; set; }
    }
    public class ActionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action _action;
        public ActionCommand(Action action)
        {
            _action = action;
        }
        public bool CanExecute(object parameter) { return true; }
        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
                _action();
        }
    }
