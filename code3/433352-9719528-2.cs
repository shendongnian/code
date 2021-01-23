    Rectangle area = someRectangle;
    // Check if the mouse position is inside the rectangle
    if (area.Contains(mousePosition))
    {
        backgroundTexture = hoverTexture;
    }
    else
    {
        backgroundTexture = defaultTexture;
    }
