    protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
        if (e.Property == UseLayoutRoundingProperty && (bool)e.NewValue)
        {
            throw new PropertyIsImmutableException("UseLayoutRounding");
        }
        //....
        base.OnPropertyChanged(e);
    }
