    private static bool changingSlider = false;
    private void anySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (! changingSlider)
        {
            changingSlider = true;      
            var thisSlider = sender as Slider;
            ...
            changingSlider = false;
    }
