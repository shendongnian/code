    public static void SavePCX(Stream pcxStream, Bitmap bmp)
    {
        if (bmp.PixelFormat != PixelFormat.Format1bppIndexed)
        {
            throw new Exception("Can only PCX bitmaps that are 1bpp indexed");
        }
        var data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);
        try
        {
            {
                //header
                pcxStream.WriteByte(10); //    char manufacturer;
                pcxStream.WriteByte(5); //char version;
                pcxStream.WriteByte(1); //char encoding;
                pcxStream.WriteByte(1); // char bpp;
                pcxStream.WriteByte(0);
                pcxStream.WriteByte(0); //char xmin[2];
                pcxStream.WriteByte(0);
                pcxStream.WriteByte(0); //char ymin[2];
                WriteWord(pcxStream, bmp.Width - 1); // char xmax[2];
                WriteWord(pcxStream, bmp.Height - 1); //char ymax[2];
                WriteWord(pcxStream, 72); //word(pcx->hdpi, 72);
                WriteWord(pcxStream, 72); // word(pcx->vdpi, 72);
                for (var i = 0; i < 16*3; i++) //4bpp palette
                {
                    pcxStream.WriteByte(0);
                }
                pcxStream.WriteByte(0); // pcx->res = 0;
                pcxStream.WriteByte(1); // pcx->nplanes = 1;
                WriteWord(pcxStream, data.Stride); // word(pcx->bytesperline, width / 2);
                WriteWord(pcxStream, 0); //word(pcx->palletteinfo, 0);
                WriteWord(pcxStream, 0); //word(pcx->hscrn, 0);
                WriteWord(pcxStream, 0); //word(pcx->vscrn, 0);
                for (var i = 0; i < 54; i++) //memset(pcx->filler, 0, 54);
                {
                    pcxStream.WriteByte(0);
                }
            } //end of header
            {
                //read all bytes to an array
                var baseLine = data.Scan0;
                // Declare an array to hold the bytes of the bitmap.
                var byteLength = data.Stride*data.Height;
                var bytes = new byte[byteLength];
                // Copy the RGB values into the array.
                for (var y = 0; y < data.Height; y++)
                {
                    var lineOffset = y*data.Stride;
                    Debug.WriteLine("Y={0}, Offset={1}", y, lineOffset);
                    for (var x = 0; x < data.Stride; x++)
                    {
                        bytes[y*data.Stride + x] = Marshal.ReadByte(baseLine, lineOffset + x);
                    }
                }
                var baseIdx = 0;
                var end = byteLength;
                var run = 0;
                var ldata = -1;
                byte ld;
                while (baseIdx < end)
                {
                    //if it matches, increase the run by 1 up to max of 63
                    if ((bytes[baseIdx] == ldata) && (run < 63)) run++;
                    else
                    {
                        //write data
                        if (run != 0) //not first run
                        {
                            ld = (byte) ldata;
                            if ((run > 1) || (ld >= 0xC0)) pcxStream.WriteByte((byte) (0xC0 | run));
                            pcxStream.WriteByte(ld);
                        }
                        run = 1;
                    }
                    ldata = bytes[baseIdx];
                    baseIdx++;
                }
                ld = (byte) ((ldata >> 4) | (ldata << 4));
                if ((run > 1) || (ld >= 0xC0)) pcxStream.WriteByte((byte) (0xC0 | run));
                pcxStream.WriteByte(ld);
            }
        }
        finally
        {
            bmp.UnlockBits(data);
        }
    }
