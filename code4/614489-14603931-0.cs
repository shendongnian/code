           try
              {
                  RenderTargetBitmap renderBitmap = new RenderTargetBitmap(
                  (int)canvBlade1Image.ActualWidth,(int)canvBlade1Image.ActualHeight,96d,
                  96d, PixelFormats.Pbgra32);
                  DrawingVisual drawingVisual = new DrawingVisual();
                  using (DrawingContext drawingContext = drawingVisual.RenderOpen())
                      drawingContext.DrawRectangle(canvBlade1Image.Background, null, new Rect(0, 0, canvBlade1Image.ActualWidth, canvBlade1Image.ActualHeight));
                  renderBitmap.Render(drawingVisual);
                  renderBitmap.Render(canvBlade1Image);
                  using (FileStream outStream = new FileStream(@"C:\Images\Keep\img1.png.", FileMode.Create))
                  {
                      PngBitmapEncoder encoder = new PngBitmapEncoder();
                      encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                      encoder.Save(outStream);
                  }
              }
