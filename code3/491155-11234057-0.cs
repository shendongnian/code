    #region INotifyPropertyChanged Members
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string prop)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    #endregion
 
