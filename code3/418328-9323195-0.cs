    public override void OnApplyTemplate()
            {
                base.OnApplyTemplate();
                Binding b = new Binding();
                b.ElementName = "TheSlider";
                b.Path = new PropertyPath("Value");
                SetBinding(ElevationAngleProperty, b);
    
            }
