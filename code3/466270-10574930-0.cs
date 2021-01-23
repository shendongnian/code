    public void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        if (!App.ViewModel.IsDataLoaded)
        {
            App.ViewModel.LoadData();
        }
    
        MedinetWebRequest mittschema = new MedinetWebRequest();
        mittschema.url = "https://medinet.se/cgi-bin/doctor.pl?action=login&customer=******&language=se";
        Action callback = () => Dispatcher.BeginInvoke(() => this.parseResults(mittschema.myresponse));
        mittschema.getrequest(callback); 
    }
