        Rectangle rect = new Rectangle(0, 0, bmOut.Width, bmOut.Height);
        System.Drawing.Imaging.BitmapData bmpData =
            bmOut.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
            bmOut.PixelFormat);
        IntPtr ptr = bmpData.Scan0;
        Byte[] bytes;
        bytes = rawIn.ReadBytes(framesize);
        for (int x = 0; x < bytes.Length; x += 2)
        {
            short[] rgb = new short[3];
            int value = bytes[x + 1] * 256 + bytes[x];
            //value = value / 32;
            value = iMax * (value - iMin) / (iMax - iMin);
            if (value < iMin)
            {
                value = iMin;
            }
            else if (value > iMax)
            {
                value = iMax;
            }
            value = 65536 * (value - iMin) / (iMax - iMin);
            rgb[0] = rgb[1] = rgb[2] = (short)(value);
            System.Runtime.InteropServices.Marshal.Copy(rgb, 0, ptr + (x) * 3, 3);
        }
        bmOut.UnlockBits(bmpData);
