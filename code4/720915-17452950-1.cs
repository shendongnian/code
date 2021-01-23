    // We could have bound the UI directly to Properties.Resources then we wouldn't be able to 
    // NotifyPropertyChanged when the culture changes 
    public string Title { get { return Properties.Resources.Title; } }
    public string Description { get { return Properties.Resources.Description; } }
    public string FarenheitLabel { get { return Properties.Resources.FarenheitLabel; } }
    public string CelsiusLabel { get { return Properties.Resources.CelsiusLabel; } }
    public string Language { get { return Properties.Resources.Language; } }
