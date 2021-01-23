    public double EllipseDiameter
    {
        get 
        {
            return (double)GetValue(EllipseDiameterProperty); 
        }
        set // default as private
        {
            SetValue(EllipseDiameterProperty, value);
        }
    }
