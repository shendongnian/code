    void SwitchCulture(CultureInfo newCulture)
    {
        Thread.CurrentThread.CurrentUICulture = newCulture;
        Thread.CurrentThread.CurrentCulture = newCulture;
        // Reload all the merged dictionaries to reset the resources.
        List<Uri> dictionaryList = new List<Uri>();
        foreach (ResourceDictionary dictionary in Application.Current.Resources.MergedDictionaries)
        {
            dictionaryList.Add(dictionary.Source);
        }
        Application.Current.Resources.MergedDictionaries.Clear();
        foreach (Uri uri in dictionaryList)
        {
            ResourceDictionary resourceDictionary1 = new ResourceDictionary();
            resourceDictionary1.Source = uri;
            Application.Current.Resources.MergedDictionaries.Add( resourceDictionary1 );
        }
        MyWindowClass newWindow = new MyWiondowClass();
        // TODO: Attach any view model so the new window looks like the old one
        newWindow.Show();
        this.Close();
    } 
