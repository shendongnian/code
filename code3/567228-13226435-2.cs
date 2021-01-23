    public ImageDetail(Image img)
    {
        pictureBox.Image = img;
        pbImage = img;
        ...
        pictureBox.Paint += pictureBox_Paint;
    }
    void pictureBox_Paint(object sender, PaintEventArgs e)
    {
        if (pbImage == null) { return; }
        var drawRect = new Rectangle(startX, startY, pictureBox.Width, pictureBox.Height);
        e.Graphics.DrawImageUnscaledAndClipped(this.pbImage, drawRect);
    }
    private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
    {
        ///... resize to what you need 
        pictureBox.Width = (int) (pbImage.Width*0.2);
        pictureBox.Height = (int) (pbImage.Height * 0.2);
        pictureBox.Invalidate();
    }
