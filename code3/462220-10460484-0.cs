    Bitmap bmp = new Bitmap(Bitmap.FromFile("oldFile"));
    
    for (int x = 0; x < bmp.Width; x++)
    {
        for (int y = 0; y < bmp.Height; y++)
        {
            Color color = bmp.GetPixel(x, y);
            int grayScale = (color.R + color.G + color.B) / 3;
            bmp.SetPixel(x,y,Color.FromArgb(grayScale, grayScale, grayScale));
        }
    }
    
    bmp.Save("newFile");
