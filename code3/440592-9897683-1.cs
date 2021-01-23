    private object _dataSource;
    public object DataSource {
        get
        {
            return _dataSource;
        }
        set
        {
            if (value != _dataSource) {
                _dataSource = value;
                UpdateTheDataGridView();
                RaiseTheDataSourceChangedEvent();
            }
        }
    }
