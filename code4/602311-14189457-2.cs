    private async void SetUser(int userId)
    {
        ServiceClient proxy = new ServiceClient();
        _user = await proxy.GetUserAsync(userId);
        NotifyOfPropertyChange();
    }
    private void NotifyOfPropertyChange() 
    {
        NotifyChanged("FirstName"); //This would raise PropertyChanged event.
        NotifyChanged("LastName");
        NotifyChanged("Email");
    }
