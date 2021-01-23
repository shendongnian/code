    private void OnCountryChanged()
    {
        var uiDispatcher = System.Windows.Application.Current.Dispatcher;
        uiDispatcher.BeginInvoke(new Action(this.CitiesView.Refresh));
    }
