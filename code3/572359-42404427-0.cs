    [System.Runtime.InteropServices.DllImport("user32.dll")]
    static extern uint GetDoubleClickTime();
    	bool _singleTapped = false;
    
            //Tapped event handler
            private async void control_Tapped(object sender, TappedRoutedEventArgs e)
            {
    	    _singleTapped = true;
                //var x = GetDoubleClickTime();
                //GetDoubleClickTime() gets the maximum number of milliseconds that can elapse between a first click and a second click
                await Task.Delay(TimeSpan.FromMilliseconds(GetDoubleClickTime()));
    
                if (!_singleTapped)
                { return; }
               //SingleTapped code
            }
    
    	    //DoubleTapped event handler
            private async void control_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
            {
                _singleTapped = false;
                //DoubleTapped code
            }
