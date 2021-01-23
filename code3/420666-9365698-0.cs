    public string Property 
    { 
       set 
        { 
          Dispatcher.BeginInvoke(()=> _property = value ) ; 
          OnPropertyChanged("Property");  
        } 
       get 
        { 
          return _property; 
        }
    }
