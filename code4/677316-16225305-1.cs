    double angle = 0;
    private void Canvas_MouseMove(object sender, MouseEventArgs e)
    {
        rotateTransform.Angle = angle; // yes, Angle is a double
        angle += 1d;
    }
