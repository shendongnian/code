    using System.IO;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    class WBmpConvertor
    {
       public void Convert(string inputFile, string outputFile, ImageFormat format)
        {
            byte[] datas = File.ReadAllBytes(inputFile);
            byte tmp;
            int width = 0, height = 0, offset = 2;
            do
            {
                tmp = datas[offset++];
                width = (width << 7) | (tmp & 0x7f);
            } while ((tmp & 0x80) != 0);
            do
            {
                tmp = datas[offset++];
                height = (height << 7) | (tmp & 0x7f);
            } while ((tmp & 0x80) != 0);
            var bmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            BitmapData bd = bmp.LockBits(new Rectangle(0, 0, width, height),
                                         ImageLockMode.WriteOnly, bmp.PixelFormat);
            int stride = (width + 7) >> 3;
            var tmpdata = new byte[height * width];
            for (int i = 0; i < height; i++)
            {
                int pos = stride * i;
                byte mask = 0x80;
                for (int j = 0; j < width; j++)
                {
                    if ((datas[offset + pos] & mask) == 0)
                        tmpdata[i * width + j] = 0;
                    else
                        tmpdata[i * width + j] = 0xff;
                    mask >>= 1;
                    if (mask == 0)
                    {
                        mask = 0x80;
                        pos++;
                    }
                }
            }
            Marshal.Copy(tmpdata, 0, bd.Scan0, tmpdata.Length);
            bmp.UnlockBits(bd);
            bmp.Save(outputFile, format);
        }
    }
