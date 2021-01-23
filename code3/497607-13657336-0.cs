        public void WBCapture()
        {
            WebBrowser wb = new WebBrowser();
            wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wb_DocumentCompleted);
            wb.ScrollBarsEnabled = true;
            wb.Width = 800;
            wb.Height = 600;
            wb.DocumentText = @"<b>Hello</b> <i>World</i>!!!";
            // Or you can navigate to:
            // wb.Navigate("http://mydocmentsurl.com");
        }
        void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wb = (WebBrowser)sender;
            using (Graphics graphics = wb.CreateGraphics())
            using (Bitmap bitmap = new Bitmap(wb.Width, wb.Height, graphics))
            {
                Rectangle bounds = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                wb.DrawToBitmap(bitmap, bounds);
                bitmap.Save(@"C:\caputre.png", ImageFormat.Png);
            }
        }
