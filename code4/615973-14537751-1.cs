    DialogResult result = openFileDialog1.ShowDialog();
    if (result == DialogResult.OK) // Test result.
    {
        Image origImage = Image.FromFile(openFileDialog1.FileName);
        pictureBoxSkin.Image = origImage;
        lblOriginalFilename.Text = openFileDialog1.SafeFileName;
        System.Drawing.Bitmap bmp = new Bitmap(16, 16);
        Graphics g3 = Graphics.FromImage(bmp);
        g3.DrawImageUnscaled(origImage, 0, 0, 16, 16);
        pictureBoxNew.Image = bmp;
        //Graphics g2 = pictureBoxNew.CreateGraphics();
        //g2.DrawImageUnscaled(bmp, 0, 0, 16, 16);
    }
