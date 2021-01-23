    public TimelinesController(IRepository repository)
    {
	_serviceTasks = new TimelineService(repository);
        repository.SavedChanges +=
            new EventHandler<RepositorySavedChangesEventArgs>(repository_SavedChanges);
    }
    private void repository_SavedChanges(object sender, RepositorySavedChangesEventArgs e)
    {
        var newDate = e.AuditDate;
        /* do something fancy with the audit date */
    }
