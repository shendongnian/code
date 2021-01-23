    public string OldData { get; set; }
    private string _newData;
    public string NewData
    {
        get { return _newData; }
        set
        {
            if (value.Equals(_newData)) { return; }
            _newData = value;
            DataChanged(this, EventArgs.Empty);
        }
    }
    private event EventHandler DataChanged;
        
    public DataHolder()
    {
            
        DataChanged = (sender, args) =>
        {
            DataHolder dataHolder = sender as DataHolder;
            if (dataHolder != null)
            {
                dataHolder.OldData = NewData;
            }
        };
    }
