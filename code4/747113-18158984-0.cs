    private void Application_Startup(object sender, StartupEventArgs e)
    {
        switch (e.InitParams["map"].ToString())
        {
            case "1":
                this.RootVisual = new MainPage();
                break;
            case "2":
                this.RootVisual = new GIS_GEOLOCATE();
                break;
            default:
                this.RootVisual = new MainPage();
                break;
        }
    }
