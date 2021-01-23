    private void Slider_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e) {
    	// try to prevent updating slider position from your view model
    	yourViewModel.DontUpdateSliderPosition = true;
    }
    
    private void Slider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e) {
    	BindingExpression be = ((Slider)sender).GetBindingExpression(RangeBase.ValueProperty);
    	if (be != null) {
    	  be.UpdateSource();
    	}
    	yourViewModel.DontUpdateSliderPosition = false;
    }
