    #region CommandWithEventArgsCommand
    DelegateCommand<MouseEventArgs> _CommandWithEventArgsCommand;
    /// <summary>
    /// Exposes <see cref="CommandWithEventArgs(MouseEventArgs)"/>.
    /// </summary>
    public DelegateCommand<MouseEventArgs> CommandWithEventArgsCommand
    {
        get { return _CommandWithEventArgsCommand ?? (_CommandWithEventArgsCommand = new DelegateCommand<MouseEventArgs>(CommandWithEventArgs)); }
    }
    #endregion
    public void CommandWithEventArgs(MouseEventArgs param)
    {
    }
        
