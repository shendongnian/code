    private void sliderName_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        Slider sliderName = sender as Slider;
        difficultyBox.Text = sliderName.Value.ToString();
    }
