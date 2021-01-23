    //invert will toggle backColor to foreColor (in fact, I mean foreColor here is the borderColor which makes your image distinct from the background).
    public static Region RegionFromPng(Bitmap bm, Color backColor, bool invert)
        {
            Region rgn = new Region();
            rgn.MakeEmpty();//This is very important            
            int argbBack = backColor.ToArgb();
            BitmapData data = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            int[] bits = new int[bm.Width * bm.Height];
            Marshal.Copy(data.Scan0, bits, 0, bits.Length);
            //
            Rectangle line = Rectangle.Empty;
            line.Height = 1;
            bool inImage = false;
            for (int i = 0; i < bm.Height; i++)
            {
                for (int j = 0; j < bm.Width; j++)
                {
                    int c = bits[j + i * bm.Width];
                    if (!inImage)
                    {
                        if (invert ? c == argbBack : c != argbBack)
                        {
                            inImage = true;
                            line.X = j;
                            line.Y = i;
                        }
                    }
                    else if(invert ? c != argbBack : c == argbBack)
                    {
                        inImage = false;
                        line.Width = j - line.X;
                        rgn.Union(line);
                    }
                }
            }
            bm.UnlockBits(data);
            return rgn;
        }
