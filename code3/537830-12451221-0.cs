    // The following line is may not be needed but is here to show how to do it
    eventbox1.GdkWindow.Events = eventbox1.GdkWindow.Events | Gdk.EventMask.ButtonPressMask;
    
    protected void OnEventbox1ButtonPressEvent (object o, ButtonPressEventArgs args)
    {
    	if( ((Gdk.EventButton)args.Event).Type == Gdk.EventType.TwoButtonPress)
    		System.Media.SystemSounds.Beep.Play (); // Play a sound if this is double-click
    }
