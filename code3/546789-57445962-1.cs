    //MouseDown EventHandler ---------
    static void MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if (sender is UserControl1)
        {
            //get control clicked
            MyControl = (UserControl1)sender;
            //get coordinates
            MPoint1 = e.GetPosition(MCanvas);
            MPoint2 = e.GetPosition(MyControl);
            //update coordinates
            MPoint1.X -= MyControl.Margin.Left + MPoint2.X;
            MPoint1.Y -= MyControl.Margin.Top + MPoint2.Y;
            //prevent mouse loosing focus of the control
            System.Windows.Input.Mouse.Capture(MyControl);
            //enable move indicator
            MMove = true;
        }
    }
