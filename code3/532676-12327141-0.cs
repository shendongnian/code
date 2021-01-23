    DateTime lastButtonClick;        // To remember the time of the most recent mouse click
    uint buttonPressed;              // To remember which mouse button was recently clicked
    uint doubleClickInterval = 300;  // Double click interval is set to 300ms
    protected void OnEventbox1ButtonPressEvent (object o, ButtonPressEventArgs args)
    {
    	lastButtonClick = DateTime.Now;
    	buttonPressed = args.Event.Button;
    	GLib.Timeout.Add (doubleClickInterval, MouseButtonWasClicked); // Set a timer
    }
    
    bool MouseButtonWasClicked()  // This time function will run 300ms after a mouse click
    {
    	if((DateTime.Now - lastButtonClick).TotalMilliseconds < doubleClickInterval)
    		MessageBox ("DoubleClick - with button #: " + buttonPressed);
    	else
    		MessageBox ("Click - with button #: " + buttonPressed);
    
    	return false;
    }
    
    void MessageBox(string text)
    {
    	MessageDialog md1 = new MessageDialog(this,DialogFlags.Modal,MessageType.Info,ButtonsType.Ok,text);
    	md1.Title = "Message box";
    	md1.Run();
    	md1.Destroy();
    }
