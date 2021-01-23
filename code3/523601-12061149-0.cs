    Slider Slider_1 = new Slider(); 
    SetProperties(Slider_1,.....)
    public void SetProperties(Slider slider,some other parameters)
    {
        slider.SetValue(Grid.ColumnProperty, 0);
        slider.Margin = new Thickness(30, 12, 0, 0);
        slider.Orientation = Orientation.Vertical;
        slider.Maximum = 10;
        slider.StepFrequency = 0.25;
        slider.TickFrequency = 0.25;
        slider.TickPlacement = TickPlacement.Outside;
        slider.Transitions = new TransitionCollection();
        slider.Transitions.Add(new EntranceThemeTransition() { });
    }
