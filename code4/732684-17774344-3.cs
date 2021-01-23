    private void SetEllipseDiameter(double width)
    {
        if (width <= 60)
        {
            EllipseDiameter = 3.0; // as default 6.0
        }
        else
        {
            EllipseDiameter = width * 0.1 + 6;
        }
    }
    private void SetEllipseOffset(double width)
    {
        if (width <= 60)
        {
            EllipseOffset = new Thickness(0, 12, 0, 0); // as default 24
        }
        else
        {
            EllipseOffset = new Thickness(0, width * 0.4 + 12, 0, 0);
        }
    }
