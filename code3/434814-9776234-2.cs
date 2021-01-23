    public static Point[] GetOutlinePoints(Bitmap image)
        {
            List<Point> outlinePoints = new List<Point>();
            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte[] originalBytes = new byte[image.Width * image.Height * 4];
            Marshal.Copy(bitmapData.Scan0, originalBytes, 0, originalBytes.Length);
            
            for (int x = 0; x < bitmapData.Width; x++)
            {
                for (int y = 0; y < bitmapData.Height; y++)
                {
                    byte alpha = originalBytes[y * bitmapData.Stride + 4 * x + 3];
                    if (alpha != 0)
                    {
                        Point p = new Point(x, y);
                        if (!ContainsPoint(outlinePoints, p))
                            outlinePoints.Add(p);
                        break;
                    }
                }
            }
            //helper variable for storing position of the last pixel visible from both sides 
            //or last inserted pixel
            int? lastInsertedPosition = null;
            
            for (int y = 0; y < bitmapData.Height; y++)
            {
                for (int x = bitmapData.Width - 1; x >= 0; x--)
                {
                    byte alpha = originalBytes[y * bitmapData.Stride + 4 * x + 3];
                    if (alpha != 0)
                    {
                        Point p = new Point(x, y);
                        if (!ContainsPoint(outlinePoints, p))
                        {
                            if (lastInsertedPosition.HasValue)
                            {
                                outlinePoints.Insert(lastInsertedPosition.Value + 1, p);
                                lastInsertedPosition += 1;
                            }
                            else
                            {
                                outlinePoints.Add(p);
                            }
                        }
                        else
                        {
                            //save last common pixel from visible from more than one sides
                            lastInsertedPosition = outlinePoints.IndexOf(p);
                        }
                        break;
                    }
                }
            }
            lastInsertedPosition = null;
            
            for (int x = bitmapData.Width - 1; x >= 0; x--)
            {
                for (int y = bitmapData.Height - 1; y >= 0; y--)
                {
                    byte alpha = originalBytes[y * bitmapData.Stride + 4 * x + 3];
                    if (alpha != 0)
                    {
                        Point p = new Point(x, y);
                        if (!ContainsPoint(outlinePoints, p))
                        {
                            if (lastInsertedPosition.HasValue)
                            {
                                outlinePoints.Insert(lastInsertedPosition.Value + 1, p);
                                lastInsertedPosition += 1;
                            }
                            else
                            {
                                outlinePoints.Add(p);
                            }
                        }
                        else
                        {
                            //save last common pixel from visible from more than one sides
                            lastInsertedPosition = outlinePoints.IndexOf(p);
                        }
                        break;
                    }
                }
            }
            lastInsertedPosition = null;
            
            for (int y = bitmapData.Height - 1; y >= 0; y--)
            {
                for (int x = 0; x < bitmapData.Width; x++)
                {
                    byte alpha = originalBytes[y * bitmapData.Stride + 4 * x + 3];
                    if (alpha != 0)
                    {
                        Point p = new Point(x, y);
                        if (!ContainsPoint(outlinePoints, p))
                        {
                            if (lastInsertedPosition.HasValue)
                            {
                                outlinePoints.Insert(lastInsertedPosition.Value + 1, p);
                                lastInsertedPosition += 1;
                            }
                            else
                            {
                                outlinePoints.Add(p);
                            }
                        }
                        else
                        {
                            //save last common pixel from visible from more than one sides
                            lastInsertedPosition = outlinePoints.IndexOf(p);
                        }
                        break;
                    }
                }
            }
            // Added to close the loop
            outlinePoints.Add(outlinePoints[0]);
            image.UnlockBits(bitmapData);
            return outlinePoints.ToArray();
        }
