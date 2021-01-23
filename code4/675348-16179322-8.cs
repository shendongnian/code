    private Project _activeProject;
    public Project ActiveProject {
      get {
        return _activeProject;
      }
      set {
        if (value == _activeProject)
          return;
        _activeProject = value;
        RaisePropertyChanged(() => ActiveProject);
      }
    }
