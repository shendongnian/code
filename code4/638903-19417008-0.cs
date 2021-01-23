      double width = 800;
      double height = 1000;
      var webView = WebCore.CreateWebView(width, height, WebViewType.Offscreen);
      webView.Source = new Uri("https://www.google.com/");
      while (webView.IsLoading)
      {
        WebCore.Update();
      }
      var bitmapSurface = (BitmapSurface)webView.Surface;
      var writeableBitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgra32, null);
      writeableBitmap.Lock();
      bitmapSurface.CopyTo(writeableBitmap.BackBuffer, bitmapSurface.RowSpan, 4, false, false);
      writeableBitmap.AddDirtyRect(new Int32Rect(0, 0, width, height));
      writeableBitmap.Unlock();
      var image = new Image();
      image.Source = writeableBitmap;
