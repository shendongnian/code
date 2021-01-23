    class MyData : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }
    
        private string _anotherProperty;
        public string AnotherProperty
        {
            get { return _anotherProperty; }
            set
            {
                _anotherProperty = value;
                RaisePropertyChanged();
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
