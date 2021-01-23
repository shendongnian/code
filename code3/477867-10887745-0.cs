    Point? lastPosition = null;
    private void myRoot_MouseDown(object sender, MouseButtonEventArgs e)
    {
        lastPosition = null;
        myRoot.CaptureMouse();
    }
    private void myRoot_MouseUp(object sender, MouseButtonEventArgs e)
    {
        myRoot.ReleaseMouseCapture();
    }
    private void myRoot_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.RightButton == MouseButtonState.Pressed)
        {
            var curPosition = Mouse.GetPosition(myRoot);
            if (lastPosition != null)
            {
                const double rotateAcceleration = 0.2;
                double newAngle = rotateTransform.Angle + ((curPosition.Y - ((Point)lastPosition).Y) * rotateAcceleration);
                if (newAngle > 360)
                    newAngle -= 360;
                if (newAngle < 0)
                    newAngle += 360;
                rotateTransform.Angle = newAngle;
                Console.WriteLine("Angle is " + newAngle.ToString());
            }
            lastPosition = curPosition;
            e.Handled = true;
        }
    }
    private void myRoot_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
    {
        Canvas.SetLeft(userControl, Canvas.GetLeft(userControl) + e.HorizontalChange);
        Canvas.SetTop(userControl, Canvas.GetTop(userControl) + e.VerticalChange);
    }
