    public Bitmap CombineAllFrames(List<Image> test)
            {
                int width = 0;
                int height = 0;
                Bitmap finalImage = null;
                try
                {
                    foreach (Bitmap bitMap in test)
                    {
                        height += bitMap.Height;
                        width = bitMap.Width > width ? bitMap.Width : width;
                    }
                    finalImage = new Bitmap(width, height);
                    using (System.Drawing.Graphics gc = Graphics.FromImage(finalImage))
                    {
                        gc.Clear(Color.White);
                        int offset = 0;
                        foreach (Bitmap bitmap in test)
                        {
                            gc.DrawImage(bitmap, new Rectangle(0, offset, bitmap.Width, bitmap.Height));
                            offset += bitmap.Width;
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return finalImage;
            }
