    public static Point[] GetOutlinePointsNEW(Bitmap image)
        {
            List<Point> outlinePoints = new List<Point>();
            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            Point currentP = new Point(0, 0);
            Point firstP = new Point(0, 0);
            byte[] originalBytes = new byte[image.Width * image.Height * 4];
            Marshal.Copy(bitmapData.Scan0, originalBytes, 0, originalBytes.Length);
            //find non-transparent pixels visible from the top of the image
            for (int x = 0; x < bitmapData.Width && outlinePoints.Count == 0; x++)
            {
                for (int y = 0; y < bitmapData.Height && outlinePoints.Count == 0; y++)
                {
                    byte alpha = originalBytes[y * bitmapData.Stride + 4 * x + 3];
                    if (alpha != 0)
                    {
                        Point p = new Point(x, y);
                        outlinePoints.Add(p);
                        currentP = p;
                        firstP = p;
                        break;
                    }
                }
            }
            Point[] neighbourPoints = new Point[] { new Point(-1, -1), new Point(0, -1), new Point(1, -1), 
                                                    new Point(1, 0), new Point(1, 1), new Point(0, 1), 
                                                    new Point(-1, 1), new Point(-1, 0) };
            //crawl around the object and look for the next pixel of the outline
            do
            {
                bool transparentNeighbourFound = false;
                bool nextPixelFound = false;
                int i;
                //searching is done in clockwise order
                for (i = 0; (i < neighbourPoints.Length * 2) && !nextPixelFound; ++i)
                {
                    int neighbourPosition = i % neighbourPoints.Length;
                    int x = currentP.X + neighbourPoints[neighbourPosition].X;
                    int y = currentP.Y + neighbourPoints[neighbourPosition].Y;
                    byte alpha = originalBytes[y * bitmapData.Stride + 4 * x + 3];
                    //a transparent pixel has to be found first
                    if (!transparentNeighbourFound)
                    {
                        if (alpha == 0)
                        {
                            transparentNeighbourFound = true;
                        }
                    }
                    else //after a transparent pixel is found, a next non-transparent one is the next pixel of the outline
                    {
                        if (alpha != 0)
                        {
                            Point p = new Point(x, y);
                            currentP = p;
                            outlinePoints.Add(p);
                            nextPixelFound = true;
                        }
                    }
                }
            } while (currentP != firstP);
            image.UnlockBits(bitmapData);
            return outlinePoints.ToArray();
        }
