    /// <summary>
    /// Builds the sequence of actions.
    /// </summary>
    /// <returns>A composite <see cref="IAction"/> which can be used to perform the actions.</returns>
    public IAction Build()
    {
        CompositeAction toReturn = this.action;
        this.action = new CompositeAction();
        return toReturn;
    }
    
    /// <summary>
    /// Performs the currently built action.
    /// </summary>
    public void Perform()
    {
        this.Build().Perform();
    }
