    [BindableAttribute(true)]
    public double Slider1Value
    {
        get { return slider1Value; }
        set
        {
            // only bind to the UI so any call to here came from the UI
            if (slider1Value == value) return;
            // do what you were going to do in value changed here
            slider1Value = value;
        }
    }
    private void clickHalf(object sender, RoutedEventArgs e)
    {
        // manipulate the private varible so set is not called
        slider1Value = slider1Value / 2;
        NotifyPropertyChanged("Slider1Value");
    }
