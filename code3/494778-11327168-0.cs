    public void MyInitialization()
    {
        listBox1.DataContext = SList;
    }
    //Observabale collection getter/setter property
    public ObservableCollection<SQuestion> SList 
    { 
        get 
        {              
            return _sList; 
        } 
        set 
        { 
            if (_sList == value) 
                return; 
            _sList = value; 
            if(PropertyChanged!= null)
                PropertyChanged(this, new PropertyChangedEventArgs("SList")); 
        } 
    }
