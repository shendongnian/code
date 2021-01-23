    void Main()
    {
            var redPinPath = @"c:\temp\pin.png";
            var redPin = Bitmap.FromFile(redPinPath);
            
            var window1 = new Form();
            window1.BackgroundImage = redPin;
            window1.Show();
            
            for(var hue = 0.01f; hue < Math.PI; hue += 0.01f)
            {
                var pinCopy = Bitmap.FromFile(redPinPath);
                AlterHue(hue, pinCopy);
                window1.BackgroundImage = pinCopy;
                window1.Invalidate();
                Application.DoEvents();
            }
    }
    
    // Define other methods and classes here
    public void AlterHue(float newHue, Image image)
    {
        var lumR = 0.213f;
        var lumG = 0.715f;
        var lumB = 0.072f;
        var cosVal = (float) Math.Cos(newHue);
        var sinVal = (float) Math.Sin(newHue);
        var imgGraphics = Graphics.FromImage(image);
        var pinAttributes = new ImageAttributes();
        var colorMatrix = new ColorMatrix(new float[][]
        {
            new float[] {lumR + cosVal * (1 - lumR) + sinVal * (-lumR),     lumG + cosVal * (-lumG) + sinVal * (-lumG),         lumB + cosVal * (-lumB) + sinVal * (1 - lumB), 0, 0},
            new float[] {lumR + cosVal * (-lumR) + sinVal * (0.143f),         lumG + cosVal * (1 - lumG) + sinVal * (0.140f),     lumB + cosVal * (-lumB) + sinVal * (-0.283f), 0, 0},
            new float[] {lumR + cosVal * (-lumR) + sinVal * (-(1 - lumR)),     lumG + cosVal * (-lumG) + sinVal * (lumG),             lumB + cosVal * (1 - lumB) + sinVal * (lumB), 0, 0},
            new float[] {0, 0, 0, 1, 0},
            new float[] {0, 0, 0, 0, 1}
        });
        
        var sizeRect = new Rectangle(0, 0, image.Width, image.Height);
        pinAttributes.SetColorMatrix(colorMatrix);
        imgGraphics.DrawImage(image, sizeRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, pinAttributes);
    }
