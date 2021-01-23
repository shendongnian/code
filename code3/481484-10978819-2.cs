    RotateTransform rt = new RotateTransform(0.0, 0.5, 0.5);
    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.I)
        {
            if (rt.Angle + 1 < 360)
            {
                rt.Angle += 1;
            }
            else
            {
                rt.Angle = 0;
            }
            MyBorder.LayoutTransform = rt;
        }
    }}
