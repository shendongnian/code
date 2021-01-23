    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(String info)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }
    public DataTable CurrentDataTable
        {
            get
            {
                return _dataTable;
            }
            set
            {
                _dataTable = value;
                OnPropertyChanged("CurrentDataTable");
            }
        }
    }
