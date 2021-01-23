        //
        // GET: /Icon/
    
        public ActionResult Index()
        {
            return View();
        }
    
        ////Icon/Icon?connected=true&heading=320&type=logo45
        public ActionResult Icon(bool connected, float heading, string type)
        {
            var dir = Server.MapPath("/images");
            //RED SQUARE IM TRYING TO PLACE ON THE BLUE RECTANGLE.
            var path = Path.Combine(dir, "mapicons/center.png");
    
            //GREEN RECTANGLE WITH FIXED YELLOW (Actual center) AND BLUE (point im really trying to find)
            var path2 = Path.Combine(dir, "mapicons/connected-marker.png");
    
            Image innerIcon = Image.FromFile(path);
            Image marker = Image.FromFile(path2);
    
            using (marker)
            {
    
                Point orginalCenter = new Point((marker.Width / 2), (marker.Height / 2));
                Bitmap markerbitmap = RotateImage(new Bitmap(marker), heading);
    
                marker = (Image)markerbitmap;
                using (var bitmap = new Bitmap(marker.Width, marker.Height))
                {
                    using (var canvas = Graphics.FromImage(bitmap))
                    {
                        PointF newCenter = RotatePoint(orginalCenter, 80, 120, heading, marker.Width, marker.Height);
                        canvas.DrawRectangle(new Pen(Color.Black), 0, 0, bitmap.Width, bitmap.Height);
                        canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        canvas.DrawImage(marker, new Rectangle(0, 0, marker.Width, marker.Height), new Rectangle(0, 0, marker.Width, marker.Height), GraphicsUnit.Pixel);
                        canvas.DrawImage(innerIcon, newCenter.X - (innerIcon.Width / 2), newCenter.Y - (innerIcon.Height / 2));
    
                        canvas.Save();
                    }
                    try
                    {
                        bitmap.Save(Path.Combine(dir, "result.png"), ImageFormat.Png);
                        path = Path.Combine(dir, "result.png");
                    }
                    catch (Exception ex) { }
                }
            }
    
    
            return base.File(path, "image/png");
        }
    
        public static Bitmap RotateImage(Bitmap b, float Angle)
        {
            // The original bitmap needs to be drawn onto a new bitmap which will probably be bigger 
            // because the corners of the original will move outside the original rectangle.
            // An easy way (OK slightly 'brute force') is to calculate the new bounding box is to calculate the positions of the 
            // corners after rotation and get the difference between the maximum and minimum x and y coordinates.
            float wOver2 = b.Width / 2.0F;
            float hOver2 = b.Height / 2.0F;
            float radians = -(float)(Angle / 180.0 * Math.PI);
            // Get the coordinates of the corners, taking the origin to be the centre of the bitmap.
            PointF[] corners = new PointF[]{
            new PointF(-wOver2, -hOver2),
            new PointF(+wOver2, -hOver2),
            new PointF(+wOver2, +hOver2),
            new PointF(-wOver2, +hOver2)
            };
    
            for (int i = 0; i < 4; i++)
            {
                PointF p = corners[i];
                PointF newP = new PointF((float)(p.X * Math.Cos(radians) - p.Y * Math.Sin(radians)), (float)(p.X * Math.Sin(radians) + p.Y * Math.Cos(radians)));
                corners[i] = newP;
            }
    
            // Find the min and max x and y coordinates.
            float minX = corners[0].X;
            float maxX = minX;
            float minY = corners[0].Y;
            float maxY = minY;
            for (int i = 1; i < 4; i++)
            {
                PointF p = corners[i];
                minX = Math.Min(minX, p.X);
                maxX = Math.Max(maxX, p.X);
                minY = Math.Min(minY, p.Y);
                maxY = Math.Max(maxY, p.Y);
            }
    
            // Get the size of the new bitmap.
            SizeF newSize = new SizeF(maxX - minX, maxY - minY);
            // ...and create it.
            Bitmap returnBitmap = new Bitmap((int)Math.Ceiling(newSize.Width), (int)Math.Ceiling(newSize.Height));
            // Now draw the old bitmap on it.
            using (Graphics g = Graphics.FromImage(returnBitmap))
            {
                g.TranslateTransform(newSize.Width / 2.0f, newSize.Height / 2.0f);
                g.RotateTransform(Angle);
    
            g.TranslateTransform(-b.Width / 2.0f, -b.Height / 2.0f);
    
                g.DrawImage(b, 0, 0);
            }
    
            return returnBitmap;
        }
    
    
        public static Point RotatePoint(Point pointToRotate, Point centerPoint, double angleInDegrees)
        {
            double angleInRadians = angleInDegrees * (Math.PI / 180);
            double cosTheta = Math.Cos(angleInRadians);
            double sinTheta = Math.Sin(angleInRadians);
    
            Point pt = new Point();
            pt.X = (int)(cosTheta * (pointToRotate.X-centerPoint.X) - sinTheta * (pointToRotate.Y-centerPoint.Y) + centerPoint.X);
    
            pt.Y = (int)(sinTheta * (pointToRotate.X - centerPoint.X) + cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y);
            //p'y = sin(theta) * (px-ox) + cos(theta) * (py-oy) + oy
    
            return pt;
    
        }
    }
