        public bool IsSelectedText
        {
            get { return isSelectedText; }
            set
            {
                isSelectedText = value;
                RaisePropertyChanged("IsSelectedText");
            }
        }
    private void SelectAllExecute()
    {
        IsSelectedText = true;
    }
