    // Add a backing field
    private IList<WeatherModel> forecasts;
    // Add a property implementing INPC
    public IList<WeatherModel> Forecasts 
    { 
        get { return forecasts; }
        private set
        {
            forecasts = value;
            this.RaisePropertyChanged("Forecasts");
        }
    }
