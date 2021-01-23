    private Slider GetSlider()
    {
	    return new Slider() {
            slider.SetValue(Grid.ColumnProperty, 1);
            slider.Margin = new Thickness(30, 12, 0, 0);
            slider.Orientation = Orientation.Vertical;
            slider.Maximum = 10;
            slider.StepFrequency = 0.25;
            slider.TickFrequency = 0.25;
            slider.TickPlacement = TickPlacement.Outside;
            slider.Transitions = new TransitionCollection();
            slider.Transitions.Add(new EntranceThemeTransition() { });
        };
    }
   
