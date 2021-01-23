    /// <summary>
    ///   This handles the click events on the window icon.
    /// </summary>
    /// <param name="sender">Click event sender</param>
    /// <param name="e">event args</param>
    private void IconMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ClickCount == 1)
        {
            if (SystemCommands.ShowSystemMenuCommand.CanExecute(null, this))
            {
                SystemCommands.ShowSystemMenuCommand.Execute(null, this);
            }
        }
        else if (e.ClickCount == 2)
        {
            if (ApplicationCommands.Close.CanExecute(null, this))
            {
                ApplicationCommands.Close.Execute(null, this);
            }
        }
    }
