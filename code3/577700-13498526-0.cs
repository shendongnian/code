    public ICommand GetProjectListCommand {
    get {
        if (getProjectListCommand == null) {
            getProjectListCommand = new RelayCommand(param => this.ProjectLogin(), CanProjectLogin());
        }
        return getProjectListCommand;
    }
