    // Fires, when user clicks on panel
    private void panel_Click(object sender, EventArgs e)
    {
        // Cast to MouseEventArgs
        MouseEventArgs mouse = (MouseEventArgs)e;
        // If mouse is within image
        if (mouse.X >= imgOriginX && mouse.Y >= imgOriginY && mouse.X < imgOriginX + imgWidth && mouse.Y < imgOriginY + imgHeight)
        {
            // do something here
        }
    }
