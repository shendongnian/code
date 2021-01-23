    public Image CreateFinalImage(string sourceFile, int circleUpperLeftX, int circleUpperLeftY, int circleDiameter) {
      Bitmap finalImage = new Bitmap(circleDiameter, circleDiameter);
      Rectangle cropRect = new Rectangle(circleUpperLeftX, circleUpperLeftY, circleDiameter, circleDiameter);
      using (Bitmap sourceImage = new Bitmap(System.Drawing.Image.FromFile(sourceFile)))
      using (Bitmap croppedImage = sourceImage.Clone(cropRect, sourceImage.PixelFormat))
      using (TextureBrush tb = new TextureBrush(croppedImage))
      using (Graphics g = Graphics.FromImage(finalImage)) {
        g.FillEllipse(tb, 0, 0, circleDiameter, circleDiameter);
      }
      return finalImage;
    }
