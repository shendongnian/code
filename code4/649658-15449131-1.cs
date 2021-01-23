    [TypeConverter(typeof (LengthConverter))]
    public double ContentHeight
    {
        get { return GetValue(ContentHeightProperty); }
        set { SetValue(ContentHeightProperty, value); }
    }
