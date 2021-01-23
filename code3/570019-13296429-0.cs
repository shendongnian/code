    class FileItem : INotifyPropertyChanged
        {
    
            public const string NamePropertyName = "CheckBoxState";
    
            private bool _checkboxstate = true;
    
            public string Name { get; set; }
    
            string _status;		
            public string Status 
    		{ 
    			get { return _status; } 
    			set { _status = value; OnPropertyChanged("Status"); } 
    		}
            
    		public bool IsSelected
            {
                get
                {
                    return _checkboxstate;
                }
                set
                {
                    if (_checkboxstate == value)
                    {
                        return;
                    }
                    _checkboxstate = value;
                    OnPropertyChanged(NamePropertyName);
                }
    
    
            }
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                if (this.PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
