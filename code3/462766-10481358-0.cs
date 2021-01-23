     public class ListHelper : INotifyPropertyChanged
        {
            private DelegateCommand<object> _command = null;
            private string _propertyName = String.Empty;
    
            public ListHelper(DelegateCommand<object> command,string propertyName)
            {
                _command = command;
                propertyName = _propertyName;
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public String Text { get; set; }
    
            private bool isChecked = false;
            public Boolean IsChecked 
            {
                get { return isChecked; }
                //The setter is executed everytime the checkbox is checked
                set 
                {
                    isChecked = value;
                    OnPropertyChanged(_propertyName);
                }
            }
    
            protected virtual void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null && _command != null)
                {
                    _command.RaiseCanExecuteChanged();
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
