    private string _surname;
    public string Surname
    {
        get { return _surname; }
        set 
        {
            if (_surname != value) // IMP: you want to inform only if value changes
            {
               string temp = Surname;
               _surname = value;
           
               // raise property change event, 
               NotifyPropertyChanged(temp, _surname);
            }
        }
    }
