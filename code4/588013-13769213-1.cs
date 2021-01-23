     public BindableCollection<string> FoldersToScan
        {
            get
            {
                return new BindableCollection<string>(Model.FoldersToScan);
            }
            set
            {
                Model.FoldersToScan = value;
                NotifyOfPropertyChange(() => FoldersToScan);
            }
        }
