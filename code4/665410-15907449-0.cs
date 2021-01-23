    private void button1_Click(object sender, EventArgs e)
    {
        //Button magic
        button1.Visible = false;
        button2.Location = button1.Location;
        Bitmap bmp = new Bitmap(this.Width, this.Height);
        this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
        pictureBox1.Image = bmp;
        //or do whatever you want with the bitmap
    }
