    public class WindowManager
    {
        public WindowManager()
        {
            VisibleWindows = new ObservableCollection<WindowViewModel>();
            VisibleWindows.CollectionChanged += OnVisibleWindowsChanged;            
        }
        public ObservableCollection<WindowViewModel> VisibleWindows {get; private set;}
        private void OnVisibleWindowsChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            // process changes, close any removed windows, open any added windows, etc.
        }
    }
    
    public class WindowViewModel : INotifyPropertyChanged
    {
        private bool _isOpen;
        private WindowManager _manager;
        public WindowViewModel(WindowManager manager)
        {
            _manager = manager;
        }
        public bool IsOpen 
        { 
            get { return _isOpen; } 
            set 
            {
                if(_isOpen && !value)
                {
                    _manager.VisibleWindows.Remove(this);
                }
                if(value && !_isOpen)
                {
                    _manager.VisibleWindows.Add(this);
                }
                _isOpen = value;
                OnPropertyChanged("IsOpen");
            }
        }    
        
        public event PropertyChangedEventHandler PropertyChanged = delegate {};
        private void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
