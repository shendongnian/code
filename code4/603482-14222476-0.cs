    void SurfaceWindow1_TouchDown(object sender, TouchEventArgs e)
    {
        LoadAnimationControl2 ani1 = new LoadAnimationControl2();
        ani1.Margin.Left = e.GetTouchPoint(this).Position.X;
        ani1.Margin.Bottom = e.GetTouchPoint(this).Position.Y;
        MainGrid.Children.Add(ani1);
    }
