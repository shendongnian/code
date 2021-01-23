    private void sliderName_ValueChanged(object sender, 
       RoutedPropertyChangedEventArgs<double> e)
    {
        // Don't use the same name used on the form if you're
        // declaring a variable here. Use a name that's local to
        // this event.
        Slider slide = sender as Slider;
        // Use the IDE-set name here.
        difficultyBox.Text = slide.Value.ToString();
    }
