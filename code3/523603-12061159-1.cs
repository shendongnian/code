    private Slider GetSlider()
    {
	    var slider = new Slider() {            
            Margin = new Thickness(30, 12, 0, 0),
            Orientation = Orientation.Vertical,
            Maximum = 10,
            StepFrequency = 0.25,
            TickFrequency = 0.25,
            TickPlacement = TickPlacement.Outside,
            Transitions = new TransitionCollection()            
        };
    
        slider.SetValue(Grid.ColumnProperty, 1);
        slider.Transitions.Add(new EntranceThemeTransition() { });
     
        return slider;
    }
   
