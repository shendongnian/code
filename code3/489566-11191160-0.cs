    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ItemViewModel> _items;
        public ViewModel()
        {
            _items = new ObservableCollection<ItemViewModel>(new List<ItemViewModel>()
                {
                    new ItemViewModel() { Label = "Item1", IsChecked = false },
                    new ItemViewModel() { Label = "Item2", IsChecked = true },
                    new ItemViewModel() { Label = "Item3", IsChecked = true },
                    new ItemViewModel() { Label = "Item4", IsChecked = false },
                    new ItemViewModel() { Label = "Item5", IsChecked = false },
                });
        }
        public ObservableCollection<ItemViewModel> Items
        {
            get
            {
                
                return this._items;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
    public class ItemViewModel  : INotifyPropertyChanged
    {
        private bool _isChecked = false;
        private string _label = "Label";
        public ICommand ButtonCommand { get; private set; }
        public ItemViewModel()
        {
            this.ButtonCommand = new DelegateCommand(Com_ButtonCommand);
        }
        public void Com_ButtonCommand(object parameter)
        {
            this.Label = "New Label text";
        }
        public string Label
        {
            get
            {
                return this._label;
            }
            set
            {
                this._label = value;
                this.OnPropertyChanged("Label");
            }
        }
        public bool IsChecked
        {
            get
            {
                return this._isChecked;
            }
            set
            {
                this._isChecked = value;
                this.OnPropertyChanged("IsChecked");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
    public class DelegateCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;
        public event EventHandler CanExecuteChanged;
        public DelegateCommand(Action<object> execute)
            : this(execute, null)
        {
        }
        public DelegateCommand(Action<object> execute,
                       Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }
            return _canExecute(parameter);
        }
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
