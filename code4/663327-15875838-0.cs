    private void timeSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
    {
        var sliderIstance = sender as Slider;
        if (sliderIstance.Value != 1)
            ApplicationData.Current.LocalSettings.Values["myTextBlockSize"] = sliderIstance.Value as double?;
        var _Frame = Window.Current.Content as Frame;
        _Frame.Navigate(_Frame.Content.GetType());
        _Frame.GoBack();
    }
