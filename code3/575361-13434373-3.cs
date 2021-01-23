    private string name;
    public string Name
    {
        get { return name; }
        set { SetProperty(ref name, value); }
    }
    
    private void SetProperty<T>(ref T field, T value, [CallerMemberName] string callerMemberName = "")
    {
        // callerMemberName = "Name" (the property that called it).
        // Set the field value and raise PropertyChanged event.
    }
