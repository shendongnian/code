    // Or whatever the type of "ctl" is ...
    private void SetPositionInVirtualCoords(Control ctl, double x, double y)
    {
        screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
        screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;        
        ctl.SetValue(Canvas.LeftProperty, x * (screenWidth/320.0));
        ctl.SetValue(Canvas.TopProperty, y * (screenHeight/240.0));
    }
