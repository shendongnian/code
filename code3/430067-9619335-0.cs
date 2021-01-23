    public Image x(string sourceFile, int circleUpperLeftX, int circleUpperLeftY, int circleDiameter) {
        using(Bitmap sourceImage = new Bitmap(sourceFile), GraphicsPath p = new GraphicsPath()) {
            Bitmap destImage = new Bitmap(circleDiameter, circleDiameter, sourceImage.PixelFormat);
    
            p.AddEllipse(circleUpperLeftX, circleUpperLeftY, circleDiameter, circleDiameter);
    
            using(Graphics g = Graphics.FromImage(destImage)) {
                g.SetClip(p);
                g.DrawImageUnscaled(sourceImage, 0, 0);
            }
    
            return destImage;
        }
    }
