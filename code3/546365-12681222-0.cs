    using (Image img = Image.FromFile(open.Filename))
    {
        Image myClone = img.Clone() as Image;
        pictureBox1.InitialImage = null;
        pictureBox1.Image = myClone;
    }
