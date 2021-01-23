    private ObservableCollection<Base> selectedProjects;
    public ObservableCollection<Base> SelectedProjects
    {
        get {
            return selectedProjects;
        }
        set {
            selectedProjects = value;
            NotifyPropertyChanged();
        }
    }
