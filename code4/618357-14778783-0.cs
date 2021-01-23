    private bool IsVisualStudio2010DesignerRunning()
    {
        using (var process = System.Diagnostics.Process.GetCurrentProcess())
        {
            const string visualStudio2010ProcessName = "devenv";
            if (process.ProcessName.ToLowerInvariant().Contains(visualStudio2010ProcessName)
                && DesignerProperties.GetIsInDesignMode(this))
            {
                return true;
            }
            else
                return false;
        }
    }
