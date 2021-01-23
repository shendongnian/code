    /// <summary>
    /// Changing Current Input Language to a next installed language
    /// </summary>
    public void ChangeInputLanguage()
    {
        // Nothing to do if there is only one Input Language supported:
        if (InputLanguage.InstalledInputLanguages.Count == 1)
            return;
        // Get index of current Input Language
        int currentLang = InputLanguage.InstalledInputLanguages.IndexOf(InputLanguage.CurrentInputLanguage);
        // Calculate next Input Language
        InputLanguage nextLang = ++currentLang == InputLanguage.InstalledInputLanguages.Count ? 
        InputLanguage.InstalledInputLanguages[0] : InputLanguage.InstalledInputLanguages[currentLang];
        // Change current Language to the calculated:
        ChangeInputLanguage(nextLang);
    }
    
    /// <summary>
    /// Changing current Input Language to a new one passed in the param
    /// </summary>
    /// <param name="ISOLang">ISO Culture name string code e.g. "en" for English</param>
    public void ChangeInputLanguage(string ISOLang)
    {
        // Convert ISO Culture name to InputLanguage object. Be aware: if ISO is not supported
        // ArgumentException will be invoked here
        InputLanguage nextLang = InputLanguage.FromCulture(new System.Globalization.CultureInfo(ISOLang));
        ChangeInputLanguage(nextLang);
    }
    
    /// <summary>
    /// Changing current Input Language to a new one passed in the param
    /// </summary>
    /// <param name="LangID">Integer Culture code e.g. 1033 for English</param>
    public void ChangeInputLanguage(int LangID)
    {
        // Convert Integer Culture code to InputLanguage object. Be aware: if Culture code is not supported
        // ArgumentException will be invoked here
        InputLanguage nextLang = InputLanguage.FromCulture(new System.Globalization.CultureInfo(LangID));
        ChangeInputLanguage(nextLang);
    }
    
    /// <summary>
    /// Changing current Input Language to a new one passed in the param
    /// </summary>
    /// <param name="InputLang">New Input Language as InputLanguage object</param>
    public void ChangeInputLanguage(InputLanguage InputLang)
    {
        // Check is this Language really installed. Raise exception to warn if it is not:
        if (InputLanguage.InstalledInputLanguages.IndexOf(InputLang) == -1)
            throw new ArgumentOutOfRangeException();
        // InputLAnguage changes here:
        InputLanguage.CurrentInputLanguage = InputLang;
    }
