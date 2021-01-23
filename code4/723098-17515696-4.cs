    private void button1_MouseMove(object sender, MouseEventArgs e)
    {
        Point relMousePos = e.Location;
        bool mouseOverButton = true;
        mouseOverButton &= relMousePos.X > 0;
        mouseOverButton &= relMousePos.X < button1.Width;
        mouseOverButton &= relMousePos.Y > 0;
        mouseOverButton &= relMousePos.Y < button1.Height;
        if (mouseOverButton != MouseButtons.None)
        {
            button1_MouseDown(sender, e);
        }
        else
        {
            button1_MouseUp(sender, e);
        }
    }
