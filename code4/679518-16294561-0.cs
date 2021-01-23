        var bmp = new Bitmap(200, 200);
        using (var g = Graphics.FromImage(bmp))
        {
            new GraphicsRenderer(
                new FixedCodeSize(200, QuietZoneModules.Two)).Draw(g, qrCode.Matrix);
        }
        pictureBox1.Image = bmp;
