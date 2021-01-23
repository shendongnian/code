    public string Temperature
    {
        get { return Model.Temperature.ToString(); }
        set
        {
            double test;
            if (double.TryParse(value, out test))
            {
                Model.Temperature = test;
            }
            else
            {
                Model.Temperature = 0D;
                Deployment.Current.Dispatcher.BeginInvoke(() => OnPropertyChanged("Temperature"));
            }
        }
    }
