    public void DrawWindow(Rect p_PositionAndSize, string p_Button2Text = "NotInUse")
    {
     	DrawWindow(p_PositionAndSize, delegate{ Thread.Sleep(1); }, p_Button2Text);
    }
    
    public void DrawWindow(Rect p_PositionAndSize, Action p_Button2Action, string p_Button2Text = "NotInUse")
    {
     // Stuff happens here
    }
