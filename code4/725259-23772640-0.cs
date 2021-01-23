    private DataView tableFromMySql;
    public DataView TableFromMySql
    {
        get { return tableFromMySql; }
        set
        {
            if (tableFromMySql == value)
                return;
            tableFromMySql = value;
            RaisePropertyChanged("TableFromMySql");
        }
    }
