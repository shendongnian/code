    class NotificationObject : INotifyPropertyChanged
    {
        public void RaisePropertyChanged(string name)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    class ComboEntry : NotificationObject
    {
        public string Name { get; private set; }
        private string _option = "Off";
        public string Option 
        {
            get { return _option; }
            set { _option = value; RaisePropertyChanged("Option"); }
        }
        public ComboEntry()
        {
            Name = Guid.NewGuid().ToString();
        }
    }
    class MyDataContext : NotificationObject
    {
        public ObservableCollection<ComboEntry> Entries { get; private set; }
        private ComboEntry _selectedEntry;
        public ComboEntry SelectedEntry
        {
            get { return _selectedEntry; }
            set { _selectedEntry = value; RaisePropertyChanged("SelectedEntry"); }
        }
        public MyDataContext()
        {
            Entries = new ObservableCollection<ComboEntry>
            {
                new ComboEntry(),
                new ComboEntry(),
                new ComboEntry()
            };
            SelectedEntry = Entries.FirstOrDefault();
        }
        public void SetOption(string value)
        {
            Entries
                .ToList()
                .ForEach(entry => entry.Option = value);
        }
    }
