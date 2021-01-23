    protected void Navigate(string address)
    {
        if (string.IsNullOrEmpty(address))
            return;
        Uri uri = new Uri(address, UriKind.Relative);
        Debug.Assert(App.Current.RootVisual is PhoneApplicationFrame);
        BeginInvoke(() =>
            ((PhoneApplicationFrame)App.Current.RootVisual).Navigate(uri));
    }
    protected void Navigate(string page, AppViewModel vm)
    {
        // this little bit adds the viewmodel to a static dictionary
        // and then a reference to the key to the new page so that pages can
        // be bound to arbitrary viewmodels based on runtime logic
        string key = vm.GetHashCode().ToString();
        ViewModelLocator.ViewModels[key] = vm;
        Navigate(string.Format("{0}?vm={1}", page, key));
    }
    protected void GoBack()
    {
        var frame = (PhoneApplicationFrame)App.Current.RootVisual;
        if (frame.CanGoBack)
            frame.GoBack();
    }
