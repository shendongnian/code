    public MainPage()
    {
        InitializeComponent();
        TouchPanel.EnabledGestures = GestureType.FreeDrag;
        Touch.FrameReported += Touch_FrameReported;
    }
    private void Touch_FrameReported(object sender, TouchFrameEventArgs e)
    {
        if (TouchPanel.IsGestureAvailable) // check only dragging 
        {
            // get point relative to Viewport
            TouchPoint mainTouch = e.GetPrimaryTouchPoint(yourMap);
            // check if drag has completed (key up)
            if (mainTouch.Action == TouchAction.Up)
            {
                // user finished operation - Key Up
                // do something for example dependant on coordinates 
                double x = mainTouch.Position.X;
                double y = mainTouch.Position.Y;
            }
        }
    }
