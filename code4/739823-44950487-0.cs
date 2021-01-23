        public void GetScreenshotWithAdorner(Canvas canvas, string filename)
        {
          AdornerLayer adornerlayer = AdornerLayer.GetAdornerLayer(canvas);
          
          RenderTargetBitmap rtb = new RenderTargetBitmap(
            (int)canvas.ActualWidth,
            (int)canvas.ActualHeight,
            96, //dip X
            96, //dpi Y
            PixelFormats.Pbgra32);
          rtb.Render(canvas); //renders the canvas screen first...
          rtb.Render(adornerlayer); //... then it renders the adorner layer
    
          SaveRTBAsPNG(rtb, filename);
        }
    
        private void SaveRTBAsPNG(RenderTargetBitmap bmp, string filename)
        {
          PngBitmapEncoder pngImage = new PngBitmapEncoder();
    
          pngImage.Frames.Add(BitmapFrame.Create(bmp));
          using (var filestream = System.IO.File.Create(filename))
          {
            pngImage.Save(filestream);
          }
        }
