    protected virtual void OnPageChanged()
    { 
        OnPageChanged(new PageChangedEventArgs(Pages.IndexOf(activePage));
    }
    // Note: this doesn't need to be virtual.
    protected void OnPageChanged(PageChangedEventArgs args)
    {
        // Null-safe event raising
        var handler = PageChanged;
        if (handler != null)
        {
            handler(this, args);
        }
    }
