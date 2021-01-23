    public void SetImage(string fileName)
    {
       // Set the size of the PictureBox control.
        //this.pictureBox1.Size = new System.Drawing.Size(140, 140);
        this.pictureBox1.Image = Image.FromFile(fileName);
    }
