        static public Point[] crawlerPoints = new Point[] { new Point(-1, -1), new Point(0, -1), new Point(1, -1),
                                                new Point(1, 0), new Point(1, 1), new Point(0, 1),
                                                new Point(-1, 1), new Point(-1, 0) };
        private BitmapData _bitmapData;
        private byte[] _originalBytes;
        private Bitmap _bitmap;  //this is loaded from an image passed in during processing
        public Point[] GetOutlinePoints()
        {
            List<Point> outlinePoints = new List<Point>();
            _originalBytes = new byte[_bitmap.Width * _bitmap.Height * 4];
            _bitmapData = _bitmap.LockBits(new Rectangle(0, 0, _bitmap.Width, _bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(_bitmapData.Scan0, _originalBytes, 0, _originalBytes.Length);
            GetFirstNonTransparentPoint(outlinePoints);
            if (outlinePoints.Count > 0) { GetNonTransparentPoints(outlinePoints); }
            _bitmap.UnlockBits(_bitmapData);
            return outlinePoints.ToArray();
        }
        private void GetFirstNonTransparentPoint(List<Point> outlinePoints)
        {
            Point firstPoint = new Point(0, 0);
            for (int x = 0; x < _bitmapData.Width; x++)
            {
                for (int y = 0; y < _bitmapData.Height; y++)
                {
                    if (!IsPointTransparent(x, y))
                    {
                        firstPoint = new Point(x, y);
                        outlinePoints.Add(firstPoint);
                        break;
                    }
                }
                if (outlinePoints.Count > 0) { break; }
            }            
        }
        private void GetNonTransparentPoints(List<Point> outlinePoints)
        {
            Point currentPoint = outlinePoints[0];
            do   //Crawl counter clock-wise around the current point
            {
                bool firstTransparentNeighbourFound = false;
                bool nextPixelFound = false;
                for (int i = 0; (i < ApplicationVariables.crawlerPoints.Length * 2) && !nextPixelFound; ++i)
                {
                    int crawlPosition = i % ApplicationVariables.crawlerPoints.Length;
                    if (!firstTransparentNeighbourFound) { firstTransparentNeighbourFound = IsCrawlPointTransparent(crawlPosition, currentPoint); }
                    else
                    {
                        if (!IsCrawlPointTransparent(crawlPosition, currentPoint))
                        {
                            outlinePoints.Add(new Point(currentPoint.X + ApplicationVariables.crawlerPoints[crawlPosition].X, currentPoint.Y + ApplicationVariables.crawlerPoints[crawlPosition].Y));
                            currentPoint = outlinePoints[outlinePoints.Count - 1];
                            nextPixelFound = true;
                        }
                    }
                }
            } while (currentPoint != outlinePoints[0]);
        }
        private bool IsCrawlPointTransparent(int crawlPosition, Point currentPoint)
        {
            int x = currentPoint.X + ApplicationVariables.crawlerPoints[crawlPosition].X;
            int y = currentPoint.Y + ApplicationVariables.crawlerPoints[crawlPosition].Y;
            if (IsCrawlInBounds(x, y)) { return IsPointTransparent(x, y); }
            return true;
        }
        private bool IsCrawlInBounds(int x, int y)
        {
            return ((x >= 0 & x < _bitmapData.Width) && (y >= 0 & y < _bitmapData.Height));
        }
        private bool IsPointTransparent(int x, int y)
        {
            return _originalBytes[(y * _bitmapData.Stride) + (4 * x) + 3] == 0;
        }
