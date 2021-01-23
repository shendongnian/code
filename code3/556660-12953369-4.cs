    private bool _isCheckedToogle1;
    public bool IsCheckedToogle1
    {
        get { return _isCheckedToogle1; }
        set
        {
            _isCheckedToogle1 = value;
            OnPropertyChanged("IsCheckedToogle1");
        }
    }
    private int _toogleButton1Value = 16;
    public int ToogleButton1Value
    {
       get { return _toogleButton1Value; }
       set
       {
          _toogleButton1Value = value;
          OnPropertyChanged("ToogleButton1Value");
       }
    }
