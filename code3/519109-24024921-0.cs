    public RelayCommand CloseCommand
    {
        get
        {
            return new RelayCommand(() => Application.Current.Windows
                .Cast<Window>()
                .Single(w => w.DataContext == this)
                .Close());
        }
    }
