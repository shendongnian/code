    public bool Reload() { return Reload(null); }
    private bool Reload(object param)
    {
        Type type = this.Frame.CurrentSourcePageType;
        if (this.Frame.BackStack.Any())
        {
            type = this.Frame.BackStack.Last().SourcePageType;
            param = this.Frame.BackStack.Last().Parameter;
        }
        try { return this.Frame.Navigate(type, param); }
        finally { this.Frame.BackStack.Remove(this.Frame.BackStack.Last()); }
    }
