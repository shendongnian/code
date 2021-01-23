    private void PrintPage(Object sender, PrintPageEventArgs ev)
            {
                if (pageImage == null)
                    return;
                ev.Graphics.PageUnit = GraphicsUnit.Pixel;
    
                ev.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                ev.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                float a = (ev.PageSettings.PrintableArea.Width / 100) * ev.Graphics.DpiX;
                float b = ((ev.PageSettings.PrintableArea.Height / 100) * ev.Graphics.DpiY);
                float scale = 1500;
                scale = 0;
                RectangleF srcRect = new RectangleF(0, startY, pageImage.Width, b - scale);
                RectangleF destRect = new RectangleF(0, 0, a, b);
                ev.Graphics.DrawImage(pageImage, destRect, srcRect, GraphicsUnit.Pixel);
                startY = startY + b - scale;
                float marignInPixel = (0.5f / 2.54f) * ev.Graphics.DpiY;
                ev.HasMorePages = (startY + marignInPixel < pageImage.Height);
            }
