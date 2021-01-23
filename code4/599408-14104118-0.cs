    public PLanguageViewModel(PLanguage pLanguage)
    {
        PLanguage = pLanguage;
	    _typeCollection = new ObservableCollection<string>(Enum.GetNames(typeof(ProjectType)));
       ...
    }
