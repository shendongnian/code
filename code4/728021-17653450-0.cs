    private void Crop_MouseMove(object sender, MouseEventArgs e)
    {
        if (mouseDown)
        {
            ep = e.Location;
            Update();
        }
    }
