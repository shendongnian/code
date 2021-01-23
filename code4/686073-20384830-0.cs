    //Add new item:
    public struct Vertex
    {
       public double X, Y, Z;
       public Vertex(double x, double y, double z)
       {
          this.X = x;
          this.Y = y;
          this.Z = z;
       }
    }
    //In page's code add:
    public PointF GetPerspectiveProjectionOf(double x, double y, double z)
    {
       double size = 2.0 * z * Math.Tan(Math.PI / 4.0);
       return new PointF((float)(x / size + 0.5), (float)(1.0 - y / size - 0.5));
    }
    public Image Upload(Image image, double distance, double spinInDegrees, int widthOfNewImage, int heightOfNewImage)
    {
       double spinInRadians = spinInDegrees * Math.PI / 180.0;
       var v1 = new Vertex((-image.Width / 2.0) * Math.Cos(spinInRadians), image.Height / 2.0, (-image.Width / 2.0) * Math.Sin(spinInRadians));
       var v2 = new Vertex(-v1.X, v1.Y, -v1.Z);
       var v3 = new Vertex(v2.X, -v2.Y, v2.Z);
       var v4 = new Vertex(v1.X, -v1.Y, v1.Z);
       v1.Z += distance;
       v2.Z += distance;
       v3.Z += distance;
       v4.Z += distance;
       if (v1.Z < 0.0 || v2.Z < 0.0 || v3.Z < 0.0 || v4.Z < 0.0)
       {
           throw new ArgumentException("You are heading too close to the spinned image! You should increase distance.", "distance");
       }
       Image img = new Bitmap(widthOfNewImage, heightOfNewImage);
       Graphics graphics = Graphics.FromImage(img);
       graphics.SmoothingMode = SmoothingMode.AntiAlias;
       SolidBrush sb = new SolidBrush(Color.Empty);
       Bitmap bitmap = (Bitmap)image;
       for (int y = 0; y < image.Height; y++)
       {
          for (int x = 0; x < image.Width; x++)
          {
              var x1 = v1.X + x * Math.Cos(spinInRadians);
              var z1 = v1.Z + x * Math.Sin(spinInRadians);
              var y1 = v1.Y - y;
              var x2 = v1.X + (x + 1) * Math.Cos(spinInRadians);
              var z2 = v1.Z + (x + 1) * Math.Sin(spinInRadians);
              var y2 = v1.Y - y - 1;
              var p1 = GetPerspectiveProjectionOf(x1, y1, z1);
              var p2 = GetPerspectiveProjectionOf(x2, y1, z2);
              var p3 = GetPerspectiveProjectionOf(x2, y2, z2);
              var p4 = GetPerspectiveProjectionOf(x1, y2, z1);
              p1.X *= widthOfNewImage;
              p1.Y *= heightOfNewImage;
              p2.X *= widthOfNewImage;
              p2.Y *= heightOfNewImage;
              p3.X *= widthOfNewImage;
              p3.Y *= heightOfNewImage;
              p4.X *= widthOfNewImage;
              p4.Y *= heightOfNewImage;
              sb.Color = bitmap.GetPixel(x, y);
              graphics.FillPolygon(sb, new PointF[] { p1, p2, p3, p4 });
          }
       }
       sb.Dispose();
       graphics.Dispose();
       return img;
    }
