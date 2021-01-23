    public Window HostWindow { /* call OnPropertyChanged! */ }
    public void CompleteAction()
    {
        if (this.HostWindow != null)
        {
            this.HostWindow.Close();
        }
        else
        {
            this.PropertyChanged += (o, e) => {
                if (e.PropertyName == "HostWindow" && this.HostWindow != null)
                {
                    var hostWindow = this.HostWindow; // prevent closure-related bugs
                    // kill it whenever it appears in the future
                    hostWindow.Loaded += (o, e) => { hostWindow.Close(); };
                    // kill it right now as well if it's been shown already
                    // (we cannot assume anything)
                    if (hostWindow.IsLoaded)
                    {
                        hostWindow.Close();
                    }
                }
            };
        }
    }
