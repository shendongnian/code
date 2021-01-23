    using( Bitmap TempImage = new Bitmap(@cwd + "\\Final.jpg", true))
    {
        pictureBox.Image = TempImage // why do => new Bitmap(TempImage); here?
        string name = textBox1.Text + ".jpg";
        MemoryStream mstr = new MemoryStream();
        pictureBox.Image.Save(mstr, pictureBox.Image.RawFormat);
        byte[] arrImage = mstr.GetBuffer();    
    }
    // after this point, you'd better not be using pictureBox either!
