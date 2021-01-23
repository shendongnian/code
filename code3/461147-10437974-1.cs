    private void YourWindowsFormsTimer_Tick(object sender, EventArgs args)
    {
      // Get the bitmap object while still on the UI thread.
      var bm = new Bitmap(panelVideoPreview.ClientSize.Width, panelVideoPreview.ClientSize.Height, PixelFormat.Format24bppRgb);
      panelVideoPreview.DrawToBitmap(bm, panelVideoPreview.ClientRectangle);
      Task.Factory
        .StartNew(() =>
        {
          // It is not safe to access the UI here.
          bool[,] ar = ConvertBitmapToByteArray(bm);
          DoSomethingWithTheArrayHereIfNecessary(ar);
          // Optionally return the byte array if you need to transfer it to the UI thread.
          return ar;
        })
        .ContinueWith((task) =>
        {
          // It is safe to access the UI here.
          // Get the returned byte array.
          bool[,] ar = task.Result;
          UpdateSomeControlIfNecessaryHere(ar);
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
