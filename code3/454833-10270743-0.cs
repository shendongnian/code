    /// <summary>
    /// Rotates the input image by theta degrees around center.
    /// </summary>
    public static Bitmap rotateCenter(Bitmap bmpSrc, float theta)
    {
        Matrix mRotate = new Matrix();
        mRotate.Translate(bmpSrc.Width / -2, bmpSrc.Height / -2, MatrixOrder.Append);
        mRotate.RotateAt(theta, new Point(0, 0), MatrixOrder.Append);
        using (GraphicsPath gp = new GraphicsPath())
        {  // transform image points by rotation matrix
            gp.AddPolygon(new Point[] { new Point(0, 0), new Point(bmpSrc.Width, 0), new Point(0, bmpSrc.Height) });
            gp.Transform(mRotate);
            PointF[] pts = gp.PathPoints;
            // create destination bitmap sized to contain rotated source image
            Rectangle bbox = boundingBox(bmpSrc, mRotate);
            Bitmap bmpDest = new Bitmap(bbox.Width, bbox.Height);
            using (Graphics gDest = Graphics.FromImage(bmpDest))
            {  // draw source into dest
                Matrix mDest = new Matrix();
                mDest.Translate(bmpDest.Width / 2, bmpDest.Height / 2, MatrixOrder.Append);
                gDest.Transform = mDest;
                gDest.DrawImage(bmpSrc, pts);
                //drawAxes(gDest, Color.Red, 0, 0, 1, 100, "");
                return bmpDest;
            }
        }
    }
    private static Rectangle boundingBox(Image img, Matrix matrix)
    {
        GraphicsUnit gu = new GraphicsUnit();
        Rectangle rImg = Rectangle.Round(img.GetBounds(ref gu));
        // Transform the four points of the image, to get the resized bounding box.
        Point topLeft = new Point(rImg.Left, rImg.Top);
        Point topRight = new Point(rImg.Right, rImg.Top);
        Point bottomRight = new Point(rImg.Right, rImg.Bottom);
        Point bottomLeft = new Point(rImg.Left, rImg.Bottom);
        Point[] points = new Point[] { topLeft, topRight, bottomRight, bottomLeft };
        GraphicsPath gp = new GraphicsPath(points,
                                                            new byte[] { (byte)PathPointType.Start, (byte)PathPointType.Line, (byte)PathPointType.Line, (byte)PathPointType.Line });
        gp.Transform(matrix);
        return Rectangle.Round(gp.GetBounds());
    }
