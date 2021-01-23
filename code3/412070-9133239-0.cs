    //Determine the maximum number of touches permited (four for WP7):
    TouchPanelCapabilities tc = TouchPanel.GetCapabilities();
    if(tc.IsConnected)
    {
        return tc.MaximumTouchCount;
    }
    
    //To read multitouch data from the touch input device you can do the following:
    // Process touch events
    TouchCollection touchColl = TouchPanel.GetState();
    foreach (TouchLocation t in touchColl)
    {
        if ((t.State == TouchLocationState.Pressed)
                || (t.State == TouchLocationState.Moved))
        {
    	//You can check the coordinates of each point (and the previous coordinate TryGetPreviousLocation())
    	float xcoordiante = t.Position.X;
    	float ycoordiante = t.Position.Y;
    
    	//Determine if touch point was moved/pressed or released use the State property
    	TouchLocationState st = t.State;
    
        }
    }
