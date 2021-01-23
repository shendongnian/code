    private void Notify()
    {
        NotifyPropertyChanged(() => PropertyTaxRate);
        NotifyPropertyChanged(() => PropertyTaxYear);
        NotifyPropertyChanged(() => PropertyTaxMonth);
    }
    
    public double PropertyTaxRate
    {
        get { return _propertyTaxRate; }
        set { 
            if (value > 1) {
                value /= 100;
            }
            if (value != _propertyTaxRate) {
                _propertyTaxRate = value;
                _propertyTaxYear = value * SharedValues.HomeValue;
                _propertyTaxMonth = _propertyTaxYear / 12;
                Notify();
            }
        }
    }
    public double PropertyTaxMonth
    {
        get { return _propertyTaxMonth; }
        set {
            if (value != _propertyTaxMonth) {
                _propertyTaxMonth = value;
                _propertyTaxYear = 12 * value;
                _propertyTaxRate =  _propertyTaxYear / SharedValues.HomeValue;
                Notify();
            }
        }
    }
    public double PropertyTaxYear
    {
        get{ return _propertyTaxYear; }
        set { 
            if (value != _propertyTaxYear) {
                _propertyTaxYear = value;
                _propertyTaxMonth = value / 12;
                _propertyTaxRate = value / SharedValues.HomeValue;
                Notify();
            }
        }
    }
