    // Members
    ObservableCollection<CProject> projectList;
    
    // Properties
    public ObservableCollection<CProject> ProjectList {
        get { return projectList; }
        set {
            projectList = value;
            OnPropertyChanged("ProjectList");
        }
    }
    this.ProjectList = new ObservableCollection<CProject>(client.getProjectList(username, password));
