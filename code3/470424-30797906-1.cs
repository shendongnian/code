    protected override void OnMouseWheel(MouseEventArgs ea)
        {
            //  flag = 1;
            // Override OnMouseWheel event, for zooming in/out with the scroll wheel
            if (picmap1.Image != null)
            {
                // If the mouse wheel is moved forward (Zoom in)
                if (ea.Delta > 0)
                {
                    // Check if the pictureBox dimensions are in range (15 is the minimum and maximum zoom level)
                    if ((picmap1.Width < (15 * this.Width)) && (picmap1.Height < (15 * this.Height)))
                    {
                        // Change the size of the picturebox, multiply it by the ZOOMFACTOR
                        picmap1.Width = (int)(picmap1.Width * 1.25);
                        picmap1.Height = (int)(picmap1.Height * 1.25);
                        // Formula to move the picturebox, to zoom in the point selected by the mouse cursor
                        picmap1.Top = (int)(ea.Y - 1.25 * (ea.Y - picmap1.Top));
                        picmap1.Left = (int)(ea.X - 1.25 * (ea.X - picmap1.Left));
                    }
                }
                else
                {
                    // Check if the pictureBox dimensions are in range (15 is the minimum and maximum zoom level)
                    if ((picmap1.Width > (imagemappan.Width)) && (picmap1.Height > (imagemappan.Height)))
                    {// Change the size of the picturebox, divide it by the ZOOMFACTOR
                        picmap1.Width = (int)(picmap1.Width / 1.25);
                        picmap1.Height = (int)(picmap1.Height / 1.25);
                        // Formula to move the picturebox, to zoom in the point selected by the mouse cursor
                        picmap1.Top = (int)(ea.Y - 0.80 * (ea.Y - picmap1.Top));
                        picmap1.Left = (int)(ea.X - 0.80 * (ea.X - picmap1.Left));
                    }
                }
            }
        }
       
