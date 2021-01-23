    //temp visual
    DrawingVisual tmpVisual = new DrawingVisual();
    using (DrawingContext dc = tmpVisual.RenderOpen())
    {
         for (Int32 x = 0; x < widthCount; x++)
              for (Int32 y = 0; y < heightCount; y++)
              {
                  Color c;
                  Double value = mass[x, y];
                  c = GetColorByValue(value);
                  dc.DrawRectangle(new SolidColorBrush(c), null,
                      new Rect(x * step - step / 2, y * step - step / 2, step, step));
              }
    }
    //resize visual
    tmpVisual.Transform = new ScaleTransform(maxWidth/(widthCount * step),
                            maxHeight/(heightCount * step));
    //visual to bitmap
    RenderTargetBitmap bitmap = 
        new RenderTargetBitmap(maxWidth, maxHeight, 96, 96, PixelFormats.Pbgra32);
    bitmap.Render(tmpVisual);
    using (DrawingContext dc = Canvas.RenderOpen())
    {
        Rect rect = new Rect(0, 0, widthCount * step, heightCount * step);
        dc.DrawImage(bitmap, rect);
    }
