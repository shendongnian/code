    if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
    {
        txtIcon.Text = openFileDialog1.FileName;
        Image oldImage = pictureBox1.Image;
        pictureBox1.Image = Image.FromFile(txtIcon.Text);
        if (oldImage != null)
        {
            oldImage.Dispose();
        }
        pictureBox1.Visible = true;
     }
