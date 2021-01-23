    public bool IsChecked
            {
                get { return isChecked; }
    
                set
                {
                    isChecked = value;
                    NotifyPropertyChanged("IsChecked");
                    Notifier.RaiseDataChanged();
                }
            }
