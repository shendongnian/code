    private ObservableCollection<DataGridColumn> _columnCollection = new ObservableCollection<DataGridColumn>();
            public ObservableCollection<DataGridColumn> ColumnCollection
            {
                get
                {
                    return this._columnCollection;
                }
                set
                {
                    _columnCollection = value;
                    base.OnPropertyChanged("ColumnCollection");
                    //Error
                    //base.OnPropertyChanged<ObservableCollection<DataGridColumn>>(() => this.ColumnCollection);
                }
            }
            private DataTable _datatable = new DataTable();
            public DataTable Datatable
            {
                get
                {
                    return _datatable;
                }
                set
                {
                    if (_datatable != value)
                    {
                        _datatable = value;
                    }
                    base.OnPropertyChanged("Datatable");
                }
            }
