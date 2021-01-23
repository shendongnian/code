    private object _property;  
    public object Property  
    {  
        get { return _property; }  
        set  
        {  
            if (_property != value)  
            {  
                _property = value;  
                Dispatcher.DelayInvoke("PropertyChanged_Property",(Action)(() =>
                {
                     RaisePropertyChanged("Property");   
                }),TimeSpan.FromMilliseconds(500));
            }  
        }  
    }  
