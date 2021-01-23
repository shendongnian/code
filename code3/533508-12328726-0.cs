    string filename = Application.StartupPath + "\\abc.Png";
            int width = -1;
            int height = -1;
            WebBrowser wb = new WebBrowser();
            wb.ScriptErrorsSuppressed = true;
            wb.Navigate("http://www.google.com/search?q=" + txtSearch.Text);
            while (wb.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            // Set the size of the WebBrowser control
            wb.Width = width;
            wb.Height = height;
            if (width == -1)
            {
                // Take Screenshot of the web pages full width
                wb.Width = wb.Document.Body.ScrollRectangle.Width;
            }
            if (height == -1)
            {
                // Take Screenshot of the web pages full height
                wb.Height = wb.Document.Body.ScrollRectangle.Height;
            }
            // Get a Bitmap representation of the webpage as it's rendered in the WebBrowser control
            Bitmap bitmap = new Bitmap(wb.Width, wb.Height);
            wb.DrawToBitmap(bitmap, new Rectangle(0, 0, wb.Width, wb.Height));
            wb.Dispose();
            bitmap.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
            MessageBox.Show("Image Saved");
