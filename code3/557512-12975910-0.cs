    private void combineImages()
    {   
        Bitmap source = new Bitmap("source.png");
        // add your code for cutting source to parts
        Bitmap[] parts = new Bitmap[4]; // the size of array depends on your image parts
        parts[0] = new Bitmap("1.png");
        parts[1] = new Bitmap("2.png");
        parts[2] = new Bitmap("3.png");
        parts[3] = new Bitmap("4.png");
        Bitmap output = new Bitmap(source.Width, source.Height);
        Graphics g = Graphics.FromImage(output);
        for(int i=0; i<4; i++)
        {
            Bitmap b = parts[i];
            g.DrawImageUnscaled(b, new Point(i * 50, i * 50)); // change positioning based on your needs
        }
        output.Save("output.png", ImageFormat.Png);
    }
