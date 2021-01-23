    public BindingList()
    {
        // ...
        this.Initialize();
    }
    private void Initialize()
    {
        this.allowNew = this.ItemTypeHasDefaultConstructor;
        if (typeof(INotifyPropertyChanged).IsAssignableFrom(typeof(T))) // yes! all you're right
        {
            this.raiseItemChangedEvents = true;
            foreach (T local in base.Items)
            {
                this.HookPropertyChanged(local);
            }
        }
    }
