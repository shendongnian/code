    public FeedSource SelectedDataSource
        {
            get { return _selectedDataSource; }
            set
            {
                _selectedDataSource = value;
                base.OnPropertyChanged("SelectedDataSource");
                //additional code to perform here
            }
        }
