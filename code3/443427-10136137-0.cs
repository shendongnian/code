    private DataTable m_Table
    public DataTable Table
    {
        get { return this.m_Table; }
        protected set { m_Table = value; NotifyPropertyChanged("Table"); }
    }
