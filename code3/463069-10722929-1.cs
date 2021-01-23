    public void Register()
    {
        table =(IVsRunningDocumentTable)    Package.GetGlobalService(typeof(SVsRunningDocumentTable));
        // Listen to show/hide events of docs to register activate/deactivate cursor  listeners.
        table.AdviseRunningDocTableEvents(this, out cookie);
    }
