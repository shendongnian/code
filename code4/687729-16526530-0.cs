    Public class Records : INotifyPropertyChanged
    { 
    public event PropertyChangedEventHandler PropertyChanged;
    private bool _isChecked = false;
    
    Public Records(){}
    public `bool IsChecked`
            {
                get { return _isChecked; }
                set { _isChecked = value; OnPropertyChanged("IsChecked"); }
            }
    protected void OnPropertyChanged(string name)
            {
                if ((PropertyChanged != null) && (_notification))
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
    public enum Items{One,Two,three,}
    }
