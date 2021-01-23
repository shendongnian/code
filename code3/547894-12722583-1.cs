     private void comboBox44_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nMaxBitmapHeigth = 800;
            int nMaxBitmapWidth = 950;
            if (this.pictureBox1.Image != null)
            {
                System.Drawing.Bitmap bmpNew = new System.Drawing.Bitmap(this.pictureBox1.Image, new System.Drawing.Size(nMaxBitmapHeigth, nMaxBitmapWidth));
                System.Drawing.Bitmap bmpOrg = null;     
            }
            // after this is the code for resizing the image to show on another picture box.
        }
