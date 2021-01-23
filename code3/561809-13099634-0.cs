    public DelegateCommand<object> MyDeleteCommand { get; set; }
    
    string _mySelectedItem;
        public string MySelectedItem
        {
            get { return _mySelectedItem; }
            set
            {
                _mySelectedItem = value;
                OnPropertyChanged("MySelectedItem");
                MyDeleteCommand.RaiseCanExecuteChanged();
            }
        }
