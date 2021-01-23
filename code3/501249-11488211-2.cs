    OpenFileDialog open = new OpenFileDialog();
    if (open.ShowDialog() == DialogResult.OK)
    {
        // display image in picture box
        Image img = new Bitmap(open.FileName);
        picBox.Image = img;
        // Byte Array that can store as BLOB in DB
        byte[] blobData = ImageToByteArray(img);
    }
