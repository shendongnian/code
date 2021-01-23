         Bitmap newBitmap = new Bitmap(bitmap);
         Graphics g = Graphics.FromImage(newBitmap);
         // Trigonometry: Tangent = Opposite / Adjacent
         double tangent = (double)newBitmap.Height / 
                          (double)newBitmap.Width;
         // convert arctangent to degrees
         double angle = Math.Atan(tangent) * (180/Math.PI);
         // a^2 = b^2 + c^2 ; a = sqrt(b^2 + c^2)
         double halfHypotenuse =(Math.Sqrt((newBitmap.Height 
                                * newBitmap.Height) +
                                (newBitmap.Width * 
                                newBitmap.Width))) / 2;
         // Horizontally and vertically aligned the string
         // This makes the placement Point the physical 
         // center of the string instead of top-left.
         StringFormat stringFormat = new StringFormat();
         stringFormat.Alignment = StringAlignment.Center;
         stringFormat.LineAlignment=StringAlignment.Center;
         g.RotateTransform((float)angle);            
         g.DrawString(waterMarkText, font, new SolidBrush(color),
                      new Point((int)halfHypotenuse, 0), 
                      stringFormat);
