    UILanguages languages = new UILanguages();
    languages.Add(
        new UILanguage
        {
            Culture = "en",
            SpecCulture = "en-US",
            EnglishName = "English"
        });
    languages.Add(
        new UILanguage
        {
            Culture = "es",
            SpecCulture = "es-ES",
            EnglishName = "Spanish"
        });
    CollectionViewSource cvs = new CollectionViewSource
    {
        Source = languages
    };
    cmbLanguages.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = cvs });
