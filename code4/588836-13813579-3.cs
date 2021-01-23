    /// <summary>
    /// Handle a KeyDown event and check for Hardbutton Return key
    /// </summary>
    /// <param name="e">A KeyEventArgs instance</param>
    public override void HandleKeyDown(KeyEventArgs e)
    {
        if (e.KeyValue == 13)
        {
            if (!InputHelper.IsSipKeyPress(13, base.Handle))
            {
                CompleteProcess();
            }
        }
        base.HandleKeyDown(e);
    }  
         
