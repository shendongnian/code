    #region CommandWithEventArgs
    DelegateCommand<MouseEventArgs> _CommandWithEventArgs;
    /// <summary>
    /// Exposes <see cref="CommandWithEventArgs(MouseEventArgs)"/>.
    /// </summary>
    public DelegateCommand<MouseEventArgs> CommandWithEventArgs
    {
        get { return _CommandWithEventArgs ?? (_CommandWithEventArgs = new DelegateCommand<MouseEventArgs>(CommandWithEventArgs)); }
    }
    #endregion
    public void CommandWithEventArgs(MouseEventArgs param)
    {
    }
        
