    private void pictureBox_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        using (Bitmap bmp = new Bitmap("myImage.png"))
        {
            // Set the image attribute's color mappings
            ColorMap[] colorMap = new ColorMap[1];
            colorMap[0] = new ColorMap();
            colorMap[0].OldColor = Color.Black;
            colorMap[0].NewColor = Color.Blue;
            ImageAttributes attr = new ImageAttributes();
            attr.SetRemapTable(colorMap);
            // Draw using the color map
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            g.DrawImage(bmp, rect, 0, 0, rect.Width, rect.Height, GraphicsUnit.Pixel, attr);
        }
    }
