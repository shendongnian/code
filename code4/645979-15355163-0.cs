    private async Task SetPBarHelper(Action handler)
    {
        SetPBar(true);                // try to make ProgressBar visible
        System.Windows.Forms.Application.DoEvents();
        async Task.Run(handler);                    // use the event handling, which run database query
        SetPBar(false);               // try to make ProgressBar disappear
    }
