    if (ofd.ShowDialog() == DialogResult.OK)
    {
    	// Load the image the user selected
        using (Image img = Image.FromFile(ofd.FileName))
        {
            // Create a copy of it
            Bitmap bmpCopy = new Bitmap(img);
            
            // Clear out the bitmap currently in the picture box,
            // if there is one.
            if (pictureBox1.Image != null)
            {
            	pictureBox1.Image.Dispose();
            }
            
            // Assign the copy of the bitmap to the picture box.
            pictureBox1.Image = bmpCopy;
        }
    }
