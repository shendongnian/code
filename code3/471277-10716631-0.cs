    public void SaveChanges()
    {
        //_auditDate = DateTime.Now; ignore this in your case
        OnSavingChanges();
        _context.SaveChanges();
        OnSavedChanges();
    }
    private void OnSavingChanges()
    {
        if (SavingChanges != null)
        {
            var eventArgs = new RepositorySavingChangesEventArgs()
            {
                AuditDate = _auditDate
            };
            SavingChanges(this, eventArgs);
        }
    }
    public event EventHandler<RepositorySavingChangesEventArgs> SavingChanges;
    private void OnSavedChanges()
    {
        if (SavedChanges != null)
        {
            var eventArgs = new RepositorySavedChangesEventArgs()
            {
                AuditDate = _auditDate
            };
            SavedChanges(this, eventArgs);
        }
    }
    public event EventHandler<RepositorySavedChangesEventArgs> SavedChanges;
