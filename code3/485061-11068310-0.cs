    private float _celsius;
    public float Fahrenheit {
        get { return _celsius * 1.8f + 32.0f }
        set 
        { 
            float cels = (((value - 32.0f) * 5.0f) / 9.0f);
            if (cels != _celsius)
            {
                _celsius = cels;
                TempPropertiesChanged();
            }
        }
    }
    public float Celsius
    {
        get { return _celsius; }
        set
        {
            if (value != _celsius)
            {
                _celsius = value;
                TempPropertiesChanged();
            }
        }
    }
    private void TempPropertiesChanged()
    {
       OnPropertyChanged("Fahrenheit");
       OnPropertyChanged("Celsius");
    }
