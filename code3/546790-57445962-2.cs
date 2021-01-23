    //MouseMove EventHandler ---------
    static void MouseMove(object sender, System.Windows.Input.MouseEventArgs e) {
        if (sender is UserControl1) {
            //check move indicator
            if (MMove == true)
            {
                //get control moved
                MyControl = (UserControl1)sender;
                //get container pointer
                var currentPoint = e.GetPosition(MCanvas);
                //check which mouse button is pressed
                if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
                {
                    //update control margin thickness
                    MyControl.Margin = new System.Windows.Thickness(
                        currentPoint.X - MPoint1.X - MPoint2.X,
                        currentPoint.Y - MPoint1.Y - MPoint2.Y,
                        MyControl.Margin.Right,
                        MyControl.Margin.Bottom
                    );
                }
            }
        }
    }
