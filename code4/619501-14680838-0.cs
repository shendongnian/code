    [Import]
    public TransactionViewModel ViewModel
    {
        get { return (TransactionViewModel)DataContext; }
        set { DataContext = value; }
    }
