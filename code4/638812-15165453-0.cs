        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        openFileDialog1.Filter = "bmp files (*.bmp)|*.bmp";
    
        if(openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            try
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    using (myStream)
                    {
                        // Insert code to read the stream here.
                        PictureBox picBox = new PictureBox();
                        picBox.Location = drawingPanel.Location;
                        picBox.Size = drawingPanel.Size;
                        picBox.Image = new Bitmap (myStream);
                        this.Controls.Add(picBox);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }
