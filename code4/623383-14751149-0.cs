    Binding bindingSlider = new Binding("Position");
    bindingSlider.ElementName = "mediaElement";
    bindingSlider.Mode = BindingMode.TwoWay;            
    bindingSlider.Converter = (IValueConverter)Application.Current.Resources["DoubleTimeSpan"];            
    slider.SetBinding(Slider.ValueProperty, bindingSlider);
