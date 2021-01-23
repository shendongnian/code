    private Slider CreateSlider(int columnProperty, Thickness thickness, short orientation
        int maximum, double stepFrequency, double  tickFrequency, short tickPlacement )
    { Slider slider = new slider
      slider.SetValue(Grid.ColumnProperty, columnProperty);
      slider.Margin = thickness;
      slider.Orientation = orientation;
      slider.Maximum = maximum;
      slider.StepFrequency = stepFrequency;
      slider.TickFrequency = tickFrequency;
      slider.TickPlacement =tickPlacement 
      slider.Transitions = new TransitionCollection();
      slider.Transitions.Add(new EntranceThemeTransition() { });
    return slider
    
    }
