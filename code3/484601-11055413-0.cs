    SaveFileDialog sfd = new SaveFileDialog();
    sfd.Filter = "Images|*.png;*.bmp;*.jpg";
    ImageFormat format = ImageFormat.Png;
    if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
    {
        string ext = System.IO.Path.GetExtension(sfd.FileName);
        switch (ext)
        {
            case ".jpg":
                format = ImageFormat.Jpeg;
                break;
            case ".bmp":
                format = ImageFormat.Bmp;
                break;
        }
        pictureBox1.Image.Save(sfd.FileName, format);
    }
