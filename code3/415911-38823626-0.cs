    private byte[] GenerateBarCode(string data)
    {
        Pdf417Generator gen = new Pdf417Generator(data);
        int bw = 2;
        int bh = 2;
        var barcode = gen.Encode();
        var width = barcode.Columns * bh;
        var height = barcode.Rows * bh;
        Byte[] imgData;
        using (MemoryStream stream = new MemoryStream())
        {
            using (System.Drawing.Image bmp = new Bitmap(width, height))
            {
                using (Graphics graphics = Graphics.FromImage(bmp))
                {
                    int y = 0;
                    for (int r = 0; r < barcode.Rows; ++r)
                    {
                        int x = 0;
                        for (int c = 0; c < barcode.Columns; ++c)
                        {
                            if (barcode.RawData[r][c] == 1)
                            {
                                graphics.FillRectangle(Brushes.Black, x, y, bw, bh);
                            }
                            x += bw;
                        }
                        y += bh;
                    }
                }
                bmp.Save(stream, ImageFormat.Png);
            }
            imgData = stream.ToArray();
        }
        return imgData;
    }
