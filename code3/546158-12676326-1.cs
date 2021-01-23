    string IDataErrorInfo.this[string columnName]
    {
        get { return this.GetValidationError(columnName); }
    }
    private string GetValidationError(string propertyName)
    {
        var args = new DelegatedValidationEventArgs(propertyName);
        this.OnValidationRequested(args);
        return args.ValidationError;
    }
    protected virtual void OnValidationRequested(DelegatedValidationEventArgs args)
    {
        var handler = this.ValidationRequested;
        if (handler == null) {
            return;
        }
        foreach (EventHandler<DelegatedValidationEventArgs> target in handler.GetInvocationList()) {
            target.Invoke(this, args);
            if (args.Handled) {
                break;
            }
        }
    }
