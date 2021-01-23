    private void button1_Click(object sender, EventArgs e)
    {
        OpenFileDialog d = new OpenFileDialog();
        
        // allow multiple selection
        d.Multiselect = true;
        
        // filter the desired file types
        d.Filter = "JPG |*.jpg|PNG|*.png|BMP|*.bmp";
        // show the dialog and check if the selection was made
        if (d.ShowDialog() == DialogResult.OK)
        {
            foreach (string image in d.FileNames)
            {
                // create a new control
                PictureBox pb = new PictureBox();
                // assign the image
                pb.Image = new Bitmap(image);
                // add the control to the container
                flowLayoutPanel1.Controls.Add(pb);
            }
        }
    }
