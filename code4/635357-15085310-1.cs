    private DataTable dataTable;
    public DataTable DataTable
    {
        get
        {
            return dataTable;
        }
        set
        {
            dataTable = value;
            InvokePropertyChanged(new PropertyChangedEventArgs("DataTable"));
        }
    }
