    public Bitmap GenerateScreenshot(string url, int width, int height)
        {
            WebBrowser wb = new WebBrowser();
            wb.ScrollBarsEnabled = false;
            wb.ScriptErrorsSuppressed = true;
            wb.Navigate(url);
            while (wb.ReadyState != WebBrowserReadyState.Complete) { Application.DoEvents(); }
            wb.Width = width;
            wb.Height = height;
            if (width == -1)
            {
                wb.Width = wb.Document.Body.ScrollRectangle.Width;
            }
            if (height == -1)
            {
                wb.Height = wb.Document.Body.ScrollRectangle.Height;
            }
            Bitmap bitmap = new Bitmap(wb.Width, wb.Height);
            wb.DrawToBitmap(bitmap, new Rectangle(0, 0, wb.Width, wb.Height));
            wb.Dispose();
            return bitmap;
        }
