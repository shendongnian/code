    /// <summary>
    /// Called by the ASP.NET page framework to notify server controls that use composition-based 
    /// implementation to create any child controls they contain in preparation for posting back or rendering.
    /// </summary>
    protected override void CreateChildControls()
    {
        base.CreateChildControls();
        PopulateControls();
    }
