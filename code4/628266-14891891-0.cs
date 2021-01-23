    private void panel_Click(object sender, EventArgs e) // Fires, when user clicks on panel
    {
        MouseEventArgs mouse = (MouseEventArgs)e; // Cast to MouseEventArgs
        if (mouse.X >= imgOriginX && mouse.Y >= imgOriginY && mouse.X < imgOriginX + imgWidth && mouse.Y < imgOriginY + imgHeight) // If mouse is within image
        {
            // do something here
        }
    }
