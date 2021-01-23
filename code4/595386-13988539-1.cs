    public static System.Drawing.Image ScaleImage(System.Drawing.Image image, int maxHeight)
      {
          var ratio = (double)maxHeight / image.Height;
          var newWidth = (int)(image.Width * ratio);
          var newHeight = (int)(image.Height * ratio);
          var newImage = new Bitmap(newWidth, newHeight);
          using (var g = Graphics.FromImage(newImage))
          {
              g.DrawImage(image, 0, 0, newWidth, newHeight);
          }
          return newImage;
      }
