    int XCoordinate = 10;
    int YCoordinate = 5;
    foreach (Image ile in  retrurnImagesInList())
    {
        try
        {   
            PictureBox imageControl = new PictureBox();
            imageControl.Height = 100;
            imageControl.Width = 100;
            XCoordinate += imageControl.Width+2;
            if(XCoordinate  > this.Width - imageControl.Width)
            {
                YCoordinate += imageControl.Height + 2;
                XCoordinate = 10;
            }
            imageControl.Visible = true;
            imageControl.Location = new Point(XCoordinate, YCoordinate);
            Controls.Add(imageControl);
            imageControl.Image = file;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }
