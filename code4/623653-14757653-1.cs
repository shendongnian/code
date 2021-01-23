    // global to be accesible within paint
    float[] volumetransfer = new float[1];
    int[] percentages = new int[6];
    Color[] colors = new Color[6];
    private void btnTransferBottleRegenerate_Click(object sender, EventArgs e)
    {            
        /// initialization goes here
        // force pictureBox to be redrawn
        // so resizing your window won't let your rectangles disapear
        pictureBox1.Invalidate();
        using (var bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height))
        {
            pictureBox1.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            bmp.Save(@"e:\temp\test.png"); //Application.StartupPath + "\\Image\\picture1.jpg"
        }
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        // use GraphicsObject of PaintEventArgs
        Graphics G = e.Graphics;
        float pixelsPerPercent = pictureBox1.Height / volumetransfer[0];
        int drawHeight = pictureBox1.Height;
        for (int i = 0; i < percentages.Length; i++)
        {
            SolidBrush brush = new SolidBrush(colors[i]);
            drawHeight -= (int)(pixelsPerPercent * percentages[i]);
            G.FillRectangle(brush, 0, drawHeight, pictureBox1.Width, pixelsPerPercent * percentages[i]);
        }           
    }
