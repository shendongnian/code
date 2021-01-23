    int pen_thickness = 5;
    Rectangle original_rect = new Rect(0, 0, 480, 360); // using the poster's original values
    for(int i = 0; i < pen_thickness; i++)
    {
        Rectangle bigger_rect = Rectangle.Inflate(original_rect, i, i);
        wbmp.DrawRectangle(Pens.DarkGray, bigger_rect);
    }
