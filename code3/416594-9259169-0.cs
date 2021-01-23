     public static BitmapSource GenerateBitmapSource(Visual visual, double renderWidth, double renderHeight)
        {
            var bmp = new RenderTargetBitmap((int)renderWidth, (int)renderHeight, 96, 96, PixelFormats.Pbgra32);
            var dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                dc.DrawRectangle(new VisualBrush(visual), null, new Rect(0, 0, renderWidth, renderHeight));
            }
            bmp.Render(dv);
            return bmp;
        }
