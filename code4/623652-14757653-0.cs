    // global to be accesible within paint
    float[] volumetransfer = new float[1];
    int[] percentages = new int[6];
    Color[] colors = new Color[6];
    private void btnTransferBottleRegenerate_Click(object sender, EventArgs e)
    {            
        //demo purpose only
        volumetransfer[0] = 100; //float.Parse(txtTransferVolume.Text);
            
        percentages[0] = 25; //int.Parse(txtTransferNotIdentified.Text);
        percentages[1] = 15; //int.Parse(txtTransferWaterBasedMud.Text);
        percentages[2] = 15; //int.Parse(txtTransferOilBasedMud.Text);
        percentages[3] = 15; //int.Parse(txtTransferWater.Text);
        percentages[4] = 15; //int.Parse(txtTransferHydrocarbonLiq.Text);
        percentages[5] = 15; //int.Parse(txtTransferGas.Text);
            
        colors[0] = Color.Gray;
        colors[1] = Color.Chocolate;
        colors[2] = Color.SaddleBrown;
        colors[3] = Color.Blue;
        colors[4] = Color.Red;
        colors[5] = Color.Lime;
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
        // Create a Graphics object to draw on the picturebox
        Graphics G = e.Graphics;
        // Calculate the number of pixels per 1 percent
        float pixelsPerPercent = pictureBox1.Height / volumetransfer[0];
        // Keep track of the height at which to start drawing (starting from the bottom going up)
        int drawHeight = pictureBox1.Height;
        // Loop through all percentages and draw a rectangle for each
        for (int i = 0; i < percentages.Length; i++)
        {
            // Create a brush with the current color
            SolidBrush brush = new SolidBrush(colors[i]);
            // Update the height at which the next rectangle is drawn.
            drawHeight -= (int)(pixelsPerPercent * percentages[i]);
            // Draw a filled rectangle
            G.FillRectangle(brush, 0, drawHeight, pictureBox1.Width, pixelsPerPercent * percentages[i]);
        }           
    }
